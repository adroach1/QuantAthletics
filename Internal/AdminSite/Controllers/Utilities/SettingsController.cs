using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AdminSite.Settings;
using StravaApi.StravaModel.Authentication;

namespace AdminSite.Controllers.Utilities
{
    public class SettingsController : QaBaseController
    {
        private readonly AdminSiteSettingsRepository _settingsRepository;
        public SettingsController(AdminSiteSettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public AdminSiteSettings Get()
        {
            try
            {
                var settings = _settingsRepository.Load();
                return settings;
            }
            catch (Exception exc)
            {
                Logger.Error(exc, "Error while getting settings.");
                return null;
            }

        }

        public AdminSiteSettings Post(AdminSiteSettings settings)
        {
            try
            {
                _settingsRepository.Save(settings);
                return settings;
            }
            catch (Exception exc)
            {
                Logger.Error(exc, "Error while saving settings.");
                return null;
            }

        }

    }
}
