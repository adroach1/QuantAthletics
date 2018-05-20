using System.Collections.Generic;
using StravaApi.StravaModel.Athlete;

namespace StravaApi.StravaModel.Authentication
{
    public class TokenExchangeRequest: StravaRequestItem
    {
        public TokenExchangeRequest(int clientId, string clientSecret, string code)
        {
            client_id = clientId;
            client_secret = clientSecret;
            this.code = code;
        }

        public int client_id { get; private set; }
        public string client_secret { get; private set; }
        public string code { get; private set; }
        public override string RequestUrl => "https://www.strava.com/oauth/token";
        public override IEnumerable<KeyValuePair<string, string>> GetQueryParameters()
        {
            throw new System.NotImplementedException();
        }
    }


    public class TokenExchangeResponse
    {
        public string access_token { get; set; }
        public Athlete.Athlete Athlete { get; set; }
    }
}