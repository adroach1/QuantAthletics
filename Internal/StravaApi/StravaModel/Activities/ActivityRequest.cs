using System.Collections.Generic;

namespace StravaApi.StravaModel.Activities
{
    public class ActivityRequest: StravaRequestItem
    {
        public ActivityRequest(int id)
        {
            this.id = id;
        }

        public override IEnumerable<KeyValuePair<string, string>> GetQueryParameters()
        {
            yield return new KeyValuePair<string, string>("id",id.ToString());
        }

        public override string RequestUrl => "https://www.strava.com/api/v3/activities/";
        public int id { get; private set; }
        public bool include_all_efforts { get; set; }
    }
}