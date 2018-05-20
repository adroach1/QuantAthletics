using System.Collections.Generic;
using StravaApi.StravaModel.Activities;

namespace StravaApi.StravaModel.Authentication
{
    public class AuthorizationRequest : StravaRequestItem
    {
        public AuthorizationRequest(string clientId, string redirectUri)
        {
            client_id = clientId;
            redirect_uri = redirectUri;
        }
        public override IEnumerable<KeyValuePair<string, string>> GetQueryParameters()
        {
            throw new System.NotImplementedException();
        }

        public string client_id { get; private set; }
        public string redirect_uri { get; private set; }
        public string response_type => "code";
        public string approval_prompt { get; private set; } //"auto"(default) or "force"

        public string scope { get; private set; } 
        // comma delimited string of "view_private" "write" leave blank for read-only permissions
        //Access scopes
        //public	default, private activities are not returned, privacy zones are respected in stream requests
        //write modify activities, upload on the user’s behalf
        //view_private view private activities and data within privacy zones
        //view_private,write both ‘view_private’ and ‘write’ access

        public string state { get; private set; } // returned to your application
        public override string RequestUrl => "https://www.strava.com/oauth/authorize";

    }
}