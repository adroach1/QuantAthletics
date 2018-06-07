using QA.Core.Model.Users;

namespace QA.V3.Web.Models.StravaViewModels
{
    public class StravaAccountOverviewViewModel
    {
        public string StravaSyncUrl => "http://www.Strava.com";
        public string StatusMessage { get; set; }
        public ActivityDataProvider StravaActivityDataProvider { get; set; }
    }
}