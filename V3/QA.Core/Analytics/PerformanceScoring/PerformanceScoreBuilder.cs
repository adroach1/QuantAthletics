using System;
using System.Collections.Generic;
using System.Linq;
using QA.Core.Utilities;
using QA.Core.Utilities.Normalization;

namespace QA.Core.Analytics.PerformanceScoring
{
    public class PerformanceScoreBuilder
    {
        private PerformanceScoreDistanceBucketRepo _distanceBucketRepo;
        private ExpectedCurveNormalizer _expectedCurveNormalizer;
        public PerformanceScoreBuilderOptions Options { get; private set; }

        public PerformanceScoreBuilder(PerformanceScoreDistanceBucketRepo distanceBucketRepo, PerformanceScoreBuilderOptions options, ExpectedCurveNormalizer expectedCurveNormalizer)
        {
            _distanceBucketRepo = distanceBucketRepo;
            Options = options;
            _expectedCurveNormalizer = expectedCurveNormalizer;
        }

        //we will want to pass in a reactive activity items so we can began computing as data stream comes in.
        public IEnumerable<PerformanceScore> ComputePerformanceScores(Int64 athleteId, IEnumerable<ActivityItem> activityItems)
        {
            //we will want to return this as a time series at some point as well
            throw new NotImplementedException();
        }

        //we will want to pass in a reactive activity items so we can began computing as data stream comes in.
        public PerformanceScore ComputePerformanceScore(long athleteId, IEnumerable<ActivityItem> activityItems)
        {
            activityItems = activityItems.ToList();
            var date = activityItems.Max(a => a.Date);
            List<PerformanceScoreItem> allPerformanceScoreItems = new List<PerformanceScoreItem>();
            foreach (var topRatio in Options.TopRatioOfActivitiesToUse)
            {
                var performanceSourceItems = ComputePerformanceScoreItems(athleteId, activityItems,topRatio).ToList();
                allPerformanceScoreItems.AddRange(performanceSourceItems);
            }

            allPerformanceScoreItems.AddRange(ComputeRaceProjections(allPerformanceScoreItems.OfType<TopSamplePerformanceScoreItem>()));
            //allPerformanceScoreItems = NormalizeItems(allPerformanceScoreItems).ToList();
            var averageMaxWeeklyDistance = ComputeAverageMaxDiscountedDistancePerWeek(date, activityItems);
            var performanceScore = new PerformanceScore() { AthleteId = athleteId, Date = date, PerformanceScoreItems = allPerformanceScoreItems, AverageMaxDiscountedDistancePerWeek = averageMaxWeeklyDistance};
            return performanceScore;
        }

        private IEnumerable<RaceProjectionPerformanceScoreItem> ComputeRaceProjections(IEnumerable<TopSamplePerformanceScoreItem> performanceScoreItems)
        {
            var bestTopSample = performanceScoreItems.Min(p => p.TopRatioOfSample);
            var topItems = performanceScoreItems.Where(p => p.TopRatioOfSample == bestTopSample).ToList();

            //ToDo we should use the curve of sample performance items to determine top items!

            var normalizedTopItems = NormalizeItems(topItems);

            return normalizedTopItems.Select(psi => new RaceProjectionPerformanceScoreItem(psi.RpsDistanceMeters, psi.RpsSpeed*1.03));
        }

        private IEnumerable<TopSamplePerformanceScoreItem> NormalizeItems(IEnumerable<TopSamplePerformanceScoreItem> performanceScoreItems)
        {
            var items = performanceScoreItems.ToDictionary(i => i.RpsDistanceMeters, i => i.RpsSpeed);
            var worldRecordSpeeds = _distanceBucketRepo.GetWorldRecords().ToDictionary(wr => wr.Key, wr => wr.Key/ wr.Value.TotalSeconds);
            var normalizedValues = _expectedCurveNormalizer.NormalizeItems(worldRecordSpeeds, items).ToDictionary(i=>i.Key,i=>i.Value);
            foreach (var item in performanceScoreItems)
            {
                var key = item.RpsDistanceMeters;
                yield return new TopSamplePerformanceScoreItem(key,normalizedValues[key],item.TopRatioOfSample);
            }
        } 

        private IEnumerable<TopSamplePerformanceScoreItem> ComputePerformanceScoreItems(Int64 athleteId, IEnumerable<ActivityItem> activityItems, double topRatioOfActivities)
        {
            var distanceBuckets = _distanceBucketRepo.GetAll().ToList();
            var dateGroups = activityItems.GroupBy(ai => ai.Date);
            Dictionary<DistanceBucket, List<ActivityItem>> bucketActivitiesDictionary = new Dictionary<DistanceBucket, List<ActivityItem>>();
            distanceBuckets.ForEach(db=>bucketActivitiesDictionary.Add(db, new List<ActivityItem>()));
            foreach (var dateGroup in dateGroups)
            {
                var totalDateDistance = dateGroup.Sum(g => g.Distance);
                foreach (var distanceBucket in distanceBuckets)
                {
                    var activities= dateGroup.ToList();
                    var isEnoughDistanceForBucket = totalDateDistance >= distanceBucket.MinDistance;
                    if (isEnoughDistanceForBucket)
                    {
                        var optimizedActivityForBucket = AggregrateForBucket(distanceBucket, activities);
                        bucketActivitiesDictionary[distanceBucket].Add(optimizedActivityForBucket);
                    }
                }
            }

            foreach (var kvp in bucketActivitiesDictionary)
            {
                var distanceBucket = kvp.Key;
                var topActivities = GetTopActivityItems(distanceBucket, kvp.Value,topRatioOfActivities).ToList();
                var totalDuration = topActivities.Sum(a => a.Duration);
                var totalDistance = topActivities.Sum(a => a.Distance);
                var averageSpeed = totalDistance/totalDuration;
                var averageDistance = totalDistance/ topActivities.Count;
                var normalizedSpeed = ComputeNormalizedSpeed(distanceBucket, averageDistance, averageSpeed);
                var paceToRaceWeight = GetPaceToRaceWeight(topRatioOfActivities);
                var expectedRacePace = normalizedSpeed;//*paceToRaceWeight;
                var perfScoreItem = new TopSamplePerformanceScoreItem(distanceBucket.Distance,expectedRacePace,topRatioOfActivities);
                yield return perfScoreItem;
            }
            
        }

        private IEnumerable<ActivityItem> GetTopActivityItems(DistanceBucket distanceBucket, IList<ActivityItem> activities, double topRatioOfActivitiesToUse)
        {
            var totalItems = activities.Count;
            var itemsToTake = Convert.ToInt32(Math.Ceiling(totalItems * topRatioOfActivitiesToUse));
            var activitiesBySpeed = activities.OrderByDescending(ai => ComputeNormalizedSpeed(distanceBucket, ai.Distance, ai.Speed)).ToList();
            var topActivities = activitiesBySpeed.Take(itemsToTake);
            return topActivities;
        }
        private ActivityItem AggregrateForBucket(DistanceBucket distanceBucket, IList<ActivityItem> activityItems)
        {
            //var totalItems = activityItems.Count;
            //var itemsToTake = Convert.ToInt32(Math.Ceiling(totalItems * Options.TopRatioOfActivitiesToUse));
            var activitiesBySpeed = activityItems.OrderByDescending(ai => ComputeNormalizedSpeed(distanceBucket, ai.Distance, ai.Speed)).ToList();
            var bestActivitiesForDistanceBucket = new List<ActivityItem>();
            foreach (var activityItem in activitiesBySpeed)
            {
                bestActivitiesForDistanceBucket.Add(activityItem);
                if (bestActivitiesForDistanceBucket.Sum(a => a.Distance) >= distanceBucket.Distance)
                    break;
            }

            var minStartTime = bestActivitiesForDistanceBucket.Min(ai => ai.StartDateTime);
            var duration = bestActivitiesForDistanceBucket.Sum(a => a.Duration);
            var distance = bestActivitiesForDistanceBucket.Sum(a => a.Distance);
            return new ActivityItem(minStartTime,distance,duration);
        }

        private double ComputeNormalizedSpeed(DistanceBucket distanceBucket, double distance, double speed)
        {
            //using 6 percent degradation for each 2x distance
            var df = .06;
            var dp = distance>distanceBucket.Distance? 1: distance/distanceBucket.Distance;
            var degradation = (1 - dp)*df;
            var normalizedSpeed = speed * (1 - degradation);
            return normalizedSpeed;
        }

        private double GetPaceToRaceWeight(double topPercentageInSample)
        {
            if (topPercentageInSample > 1 || topPercentageInSample < 0)
                throw new InvalidOperationException("topPercentageInSample must be between 0 and 1.");
            var ptrw = .83;   //this parameter should be found empirically using training and race data for similarly skilled athletes.
            var normalizationRate = Math.Pow(Math.E, (1 - topPercentageInSample)) / Math.E;
            return ptrw* 1/normalizationRate;
            //return averageTrainingPace*ptrw/normalizationRate;
        }


        private double ComputeAverageMaxDiscountedDistancePerWeek(DateTime date, IEnumerable<ActivityItem> activityItems)
        {
            var weekGroups = activityItems.GroupBy(ai => new
            {
                ai.Date.Year,
                WeekOfYear = DateUtil.GetWeekOfYear(ai.Date),
            });
            var discountedDistanceWeeks = weekGroups.Select(g => ComputeDiscountedDistance(date, g.Sum(ai => ai.Distance), g.Max(ai => ai.Date)));
            var topDistanceWeeks = discountedDistanceWeeks.OrderByDescending(dw => dw).Take(Options.NumberWorkoutWeeksToUse);
            return topDistanceWeeks.Average();
        }

        private double ComputeDiscountedDistance(DateTime refDate, double weeklyDistance, DateTime maxWeekDate)
        {
            var weeksBack = (refDate - maxWeekDate).TotalDays/7;
            var distanceDiscountRatio = (Options.NumberWorkoutWeeksToUse-weeksBack)/ Options.NumberWorkoutWeeksToUse;
            var discountedDistance = weeklyDistance*distanceDiscountRatio;
            return discountedDistance;
        }
    }
}



//var bestNormalizedSpeed = 0.0;
//var totalDistance = 0.0;
//var totalDuration = 0.0;
            
//            foreach (var activityItem in activitiesBySpeed)
//            {
//                var newTotalDistance = totalDistance + activityItem.Distance;
//var newTotalDuration = totalDuration + activityItem.Duration;
//                if (newTotalDistance > distanceBucket.MinDistance)
//                {
//                    var newNormalizedSpeed = ComputeNormalizedSpeed(distanceBucket, newTotalDistance, newTotalDistance / newTotalDuration);
//                    if (newNormalizedSpeed<bestNormalizedSpeed)
//                        return new ActivityItem(minStartTime, newTotalDistance, newTotalDuration);
//                }
//                totalDistance = newTotalDistance;
//                totalDuration = newTotalDuration;
//            }
//            return new ActivityItem(minStartTime, totalDistance, totalDuration);