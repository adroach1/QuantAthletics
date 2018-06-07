using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.OAuth2.Infrastructure;
using StravaApi.StravaModel.Authentication;
using StravaSharp;

namespace StravaApi
{
    public class StravaManager
    {
        private readonly StravaHttpClient _stravaHttpClient;
        public StravaManager(StravaHttpClient stravaHttpClient)
        {
            _stravaHttpClient = stravaHttpClient;
        }
        public async Task<TokenExchangeResponse> ExchangeTokenAsync(TokenExchangeRequest request)
        {
            var result = await _stravaHttpClient.PostStravaRequest<TokenExchangeResponse>(request);
            await TestStravaSharp(result.Athlete.id, result.access_token);
            return result;
        }


        private Client _stravaClient;
        private int _authenticatedAthleteId;
        public  async Task<Client> InitializeStravaClientAsync(TokenExchangeRequest request)
        {
            if (_stravaClient != null)
                return _stravaClient;
            var result = await _stravaHttpClient.PostStravaRequest<TokenExchangeResponse>(request);
            _authenticatedAthleteId = result.Athlete.id;
            var stravaAuthenticator = new StravaAuthenticator(result.access_token);
            _stravaClient = new Client(stravaAuthenticator);
            return _stravaClient;
        }

        private  async Task TestStravaSharp(int athleteId, string accessToken)
        {
            var stravaAuthenticator = new StravaAuthenticator(accessToken);
            var stravaClient = new Client(stravaAuthenticator);
            var athlete = await stravaClient.Athletes.Get(athleteId);
            var activities = await stravaClient.Activities.GetAthleteActivities();
            //var followingActivities = await stravaClient.Activities.GetFollowingActivities();
            var followers = await stravaClient.Athletes.GetFollowers(athleteId);
            var premiumFollowers = followers.Where(f => f.Premium == true).ToList();
            //var airikActivity = await stravaClient.Activities.GetActivityStreams(929834736, new[] { StreamType.Distance, StreamType.Time, StreamType.GradeSmooth, StreamType.Moving, StreamType.HeartRate, StreamType.Temperature, StreamType.Altitude, StreamType.Cadence, StreamType.LatLng, StreamType.VelocitySmooth, StreamType.Watts });

            foreach (var activity in activities.Take(3))
            {
                var activityStreams = await stravaClient.Activities.GetActivityStreams(activity.Id, new[] { StreamType.Distance, StreamType.Time, StreamType.GradeSmooth, StreamType.Moving, StreamType.HeartRate, StreamType.Temperature,StreamType.Altitude, StreamType.Cadence,StreamType.LatLng,StreamType.VelocitySmooth, StreamType.Watts });
                var activityDetails = await stravaClient.Activities.Get(activity.Id, true);
                var activityLaps = await stravaClient.Activities.GetLaps(activity.Id);
                var activityKudos = await stravaClient.Activities.GetKudoers(activity.Id);
            }
            var stravaat = StravaSharp.ActivityType.Ride;
        }

        


    }

    public class StravaAuthenticator : RestSharp.Portable.IAuthenticator
    {
        public string AccessToken { get; private set; }

        public StravaAuthenticator(string accessToken)
        {
            AccessToken = accessToken;
        }

        #region IAuthenticator implementation

        public bool CanPreAuthenticate(IRestClient client, IRestRequest request, System.Net.ICredentials credentials)
        {
            return true;
        }

        public bool CanPreAuthenticate(IHttpClient client, IHttpRequestMessage request, System.Net.ICredentials credentials)
        {
            return false;
        }

        public bool CanHandleChallenge(IHttpClient client, IHttpRequestMessage request, System.Net.ICredentials credentials, IHttpResponseMessage response)
        {
            return false;
        }

        public System.Threading.Tasks.Task PreAuthenticate(IRestClient client, IRestRequest request, System.Net.ICredentials credentials)
        {
            return Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(AccessToken))
                    request.AddHeader("Authorization", "Bearer " + AccessToken);
            });
        }

        public System.Threading.Tasks.Task PreAuthenticate(IHttpClient client, IHttpRequestMessage request, System.Net.ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task HandleChallenge(IHttpClient client, IHttpRequestMessage request, System.Net.ICredentials credentials, IHttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
