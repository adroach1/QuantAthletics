using System;
using System.Threading.Tasks;
using System.Web.Http;
using AdminSite.Settings;
using NLog;
using StravaApi;
using StravaApi.StravaModel.Authentication;

namespace AdminSite.Controllers.UserRegistration
{

    public class LoadAthleteDataController : ApiController
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly StravaManager _stravaManager;
        private readonly AdminSiteSettingsRepository _settingsRepository;

        public LoadAthleteDataController(StravaManager stravaManager, AdminSiteSettingsRepository settingsRepository)
        {
            _stravaManager = stravaManager;
            _settingsRepository = settingsRepository;
        }

        public async Task<int> GetAsync()
        {
            try
            {
                var auth = _settingsRepository.CurrentSettings.DefaultStravaClientAuth;
                var tokenExchangeRequest = new TokenExchangeRequest(auth.ClientId,auth.ClientSecret,auth.Code);
                var result = await _stravaManager.ExchangeTokenAsync(tokenExchangeRequest);
                return 1;
            }
            catch (Exception exc)
            {
                _logger.Error(exc,"Error while getting load athlete data.");
                return 0;
            }
            
        }
    }
}
