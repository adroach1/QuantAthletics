using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StravaApi.StravaModel.Authentication;

namespace AdminSite.Settings
{
    public class AdminSiteSettingsRepository
    {
        private readonly string _settingsFileLocation;

        public AdminSiteSettingsRepository(string settingsFileLocation)
        {
            _settingsFileLocation = settingsFileLocation;
        }

        public AdminSiteSettings CurrentSettings { get; private set; }

        public AdminSiteSettings Load()
        {
            var settings = JsonConvert.DeserializeObject<AdminSiteSettings>(File.ReadAllText(_settingsFileLocation));
            CurrentSettings = settings;
            return settings;
        }

        public void Save(AdminSiteSettings settings)
        {
            
            File.WriteAllText(_settingsFileLocation, JsonConvert.SerializeObject(settings));
        }
    }

    public class AdminSiteSettings
    {
        public AdminSiteSettings()
        {
            
        }

        public DefaultStravaClientAuth DefaultStravaClientAuth { get; set; }

    }

    public class DefaultStravaClientAuth
    {
        public int ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Code { get; set; }
    }

}