using System.Collections.Generic;
using System.Linq;
using QA.Core.Model;
using QA.Core.Model.Users;

namespace QA.V3.Web.Models.AthleteViewModels
{
    public class AthleteOverviewViewModel
    {
        public string StatusMessage { get; set; }
        public Dictionary<int,ActivityDataProvider> ActivityDataProviders { get; set; } = new Dictionary<int, ActivityDataProvider>();
        public List<ActivityAccount> ActivityAccounts { get; set; } = new List<ActivityAccount>();
        public ActivityDataProvider StravaActivityDataProvider => ActivityDataProviders[ActivityDataProviderIds.Strava];

        public string GetStatusMessage()
        {
            if (ActivityAccounts.Count == 0)
                return "No athlete accounts have been synced";
            if (ActivityAccounts.Count == 1)
                return ActivityAccounts.Single().ActivityDataProvider.Name + " account has been synced";
            var accountProviderNames = ActivityAccounts.GroupBy(aa => aa.ActivityDataProvider.Name).Select(g=>g.Key);
            var accountNameSummary = string.Join(",", accountProviderNames);
            return $"{ActivityAccounts.Count} total accounts for {accountNameSummary} have been synced.";
        }
    }
}