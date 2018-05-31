using System;

namespace QA.Core.Analytics.PerformanceScoring
{
    public abstract class PerformanceScoreItem
    {
        protected PerformanceScoreItem(double rpsDistanceMeters, double rpsSpeed)
        {
            RpsDistanceMeters = rpsDistanceMeters;
            RpsSpeed = rpsSpeed;
        }
        public double RpsSpeed { get; private set; }
        public double RpsDistanceMeters { get; private set; }

        public string Description => ToString();
        public override string ToString()
        {
            if (double.IsNaN(RpsSpeed) || RpsSpeed == 0 || RpsDistanceMeters == 0)
                return "Invalid Performance Score";
            var miles = RpsDistanceMeters / 1609;
            var totalSeconds = RpsDistanceMeters / RpsSpeed;
            var secondsPerMile = totalSeconds / miles;
            var perMilePace = new TimeSpan(0, 0, 0, Convert.ToInt32(secondsPerMile));
            return $"{DescriptionPrefix}{miles}M @{perMilePace}{DescriptionSuffix}";
        }

        public virtual string DescriptionPrefix => "";
        public virtual string DescriptionSuffix => "";
    }

    public class RaceProjectionPerformanceScoreItem : PerformanceScoreItem
    {
        public RaceProjectionPerformanceScoreItem(double rpsDistanceMeters, double rpsSpeed) : base(rpsDistanceMeters, rpsSpeed) { }
        public override string DescriptionPrefix => "Projected Race Performance: ";
    }

    public class TopSamplePerformanceScoreItem: PerformanceScoreItem
    {
        public TopSamplePerformanceScoreItem(double rpsDistanceMeters, double rpsSpeed, double topRatioOfSample):base(rpsDistanceMeters,rpsSpeed)
        {
            TopRatioOfSample = topRatioOfSample;
        }
        public double TopRatioOfSample { get; private set; }
        public override string DescriptionSuffix => $" Top {TopRatioOfSample*100}%";
    }


}