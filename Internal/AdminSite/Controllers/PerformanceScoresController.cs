using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using QA.Core.Analytics.PerformanceScoring;
using StravaApi;

namespace AdminSite.Controllers
{
    public class PerformanceScoresController : ApiController
    {
        private readonly PerformanceScoreBuilder _performanceScoreBuilder;
        private StravaActivityItemRepository _stravaActivityItemRepository;

        public PerformanceScoresController(PerformanceScoreBuilder performanceScoreBuilder, StravaActivityItemRepository stravaActivityItemRepository)
        {
            _performanceScoreBuilder = performanceScoreBuilder;
            _stravaActivityItemRepository = stravaActivityItemRepository;
        }

        public async Task<PerformanceScore> Get()
        {
            //var testData = GetTestActivityItems().ToList();
            var adamRoachData = await _stravaActivityItemRepository.GetDetailedActivityItemsFromStravaAsync(1);
            var perfScore = _performanceScoreBuilder.ComputePerformanceScore(1, adamRoachData);
            return perfScore;
        }


        private IEnumerable<ActivityItem> GetTestActivityItems()
        {
            yield return BuildActivityItem(1, 10, 6.5);
            yield return BuildActivityItem(2, 4, 7.1);
            yield return BuildActivityItem(3, 20, 5.9);
            yield return BuildActivityItem(4, 4, 7.1);
            yield return BuildActivityItem(5, 7, 7.1);
            yield return BuildActivityItem(6, 1, 5);
            yield return BuildActivityItem(6, 1, 5);
            yield return BuildActivityItem(6, 1, 5);
            yield return BuildActivityItem(6, 1, 5.3);
            yield return BuildActivityItem(6, 1, 5.5);
            yield return BuildActivityItem(6, 1, 5.4);
            yield return BuildActivityItem(7, 6, 7.8);
            yield return BuildActivityItem(8, 6, 7.8);
            yield return BuildActivityItem(11, 10, 6.5);
            yield return BuildActivityItem(12, 4, 7.1);
            yield return BuildActivityItem(13, 20, 5.8);
            yield return BuildActivityItem(14, 4, 7.1);
            yield return BuildActivityItem(15, 7, 7.1);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(16, 1, 5);
            yield return BuildActivityItem(17, 6, 7.8);
            yield return BuildActivityItem(18, 3, 4.9);
        }

        private ActivityItem BuildActivityItem(int day, double distanceInMiles, double pacePerMile)
        {
            return new ActivityItem(new DateTime(2017,1,1).AddDays(day),distanceInMiles*1609,pacePerMile*distanceInMiles*60);
        }

    }
}