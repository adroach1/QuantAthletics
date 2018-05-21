using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using StravaApi;
using StravaApi.StravaModel.Authentication;

namespace AdminSite.Controllers
{
    public class LoadAthleteDataController : ApiController
    {
        private readonly StravaManager _stravaManager;

        public LoadAthleteDataController(StravaManager stravaManager)
        {
            _stravaManager = stravaManager;
        }

        public async Task<int> GetAsync()
        {
            var tokenExchangeRequest = new TokenExchangeRequest(17076, "bf9a1dbc8f516d9d9293eb29db56bfc9165b670d", "0bcaba6ad698d5787622c3e06ea0531c19c663b5");
            var result = await _stravaManager.ExchangeTokenAsync(tokenExchangeRequest);
            return 1;
        }

     
       
    }
}
