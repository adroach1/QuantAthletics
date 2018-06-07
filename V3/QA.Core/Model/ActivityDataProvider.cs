using System.Security.Policy;

namespace QA.Core.Model.Users
{
    public static class ActivityDataProviderIds
    {
        public static int Strava = 1;
    }
    
    public class ActivityDataProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GrantAccessUrl { get; set; }
        public string ClientId { get; set; }
        public string RedirectUrl { get; set; }

        public string GetFullGrantAccessUrl()
        {
            if(Id == ActivityDataProviderIds.Strava)
                return $"{GrantAccessUrl}?client_id={ClientId}&redirect_uri={RedirectUrl}&response_type=code&scope=public&state=default";
            return null;
        }
    }
}
