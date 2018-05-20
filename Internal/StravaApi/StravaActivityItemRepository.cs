using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QA.Core.Analytics.PerformanceScoring;
using StravaApi.StravaModel.Authentication;
using StravaSharp;

namespace StravaApi
{
    public class StravaActivityItemRepository
    {
        private TokenExchangeRepository _tokenExchangeRepository;
        private StravaManager _stravaManager;

        public StravaActivityItemRepository(TokenExchangeRepository tokenExchangeRepository, StravaManager stravaManager)
        {
            _tokenExchangeRepository = tokenExchangeRepository;
            _stravaManager = stravaManager;
        }

        public async Task<IEnumerable<ActivityItem>> GetActivityItemsSplitsFromStravaAsync(int athleteId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActivityItem>> GetActivityItemsFromStravaAsync(int athleteId)
        {
            var athleteToken = _tokenExchangeRepository.GetAll().First();
            var stravaClient = await _stravaManager.InitializeStravaClientAsync(athleteToken);
            //var athleteActivities = await stravaClient.Activities.GetAthleteActivities(new DateTime(2017, 4, 21), new DateTime(2017, 1, 1));
            var athleteActivities = await stravaClient.Activities.GetAthleteActivities(0,100);
            var activityItems = athleteActivities.Select(BuildActivityItem);
            return activityItems;
        }

        public async Task<IEnumerable<ActivityItem>> GetDetailedActivityItemsFromStravaAsync(int athleteId)
        {
            var athleteToken = _tokenExchangeRepository.GetAll().First();
            var stravaClient = await _stravaManager.InitializeStravaClientAsync(athleteToken);
            //var athleteActivities = await stravaClient.Activities.GetAthleteActivities(new DateTime(2017, 4, 21), new DateTime(2017, 1, 1));
            var athleteActivities = await stravaClient.Activities.GetAthleteActivities(0, 100);

            var lapActivityItems = new List<ActivityItem>();
            foreach (var activitySummary in athleteActivities)
            {
                var laps = await stravaClient.Activities.GetLaps(activitySummary.Id);
                lapActivityItems.AddRange(laps.Select(BuildActivityItem));
            }
            return lapActivityItems;
        }

        private ActivityItem BuildActivityItem(ActivitySummary act)
        {
            return new ActivityItem(act.Id,act.StartDate,act.Distance,act.MovingTime);
        }
    }
}