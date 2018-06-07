using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QA.V3.Web.Data;
using QA.V3.Web.Models;
using QA.V3.Web.Models.ManageViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using QA.Core.Model;
using QA.Core.Model.Users;
using QA.V3.Web.Models.AthleteViewModels;

namespace QA.V3.Web.Controllers
{
    public class AthleteController: Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _db;

        public AthleteController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<AthleteController> logger)
        {
            _db = db;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AthleteOverview()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("User with ID {UserId} is viewing athlete data", user.Id);
            var activityDataProviders = _db.ActivityDataProviders.ToList();
            var model = new AthleteOverviewViewModel();
            model.ActivityDataProviders = activityDataProviders.ToDictionary(adp => adp.Id);

            return View(nameof(AthleteOverview), model);
        }

        /// <summary>
        /// URL that is called after a user has approved access for our application.
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// see http://developers.strava.com/docs/authentication/
        [HttpGet]
        //https://localhost:44353/athlete/stravatokenexchange?state=default%29&code=1c988491eac6289ce9ca9133a0466f4aed547856&scope=public
        public async Task<IActionResult> StravaTokenExchange(string client_id, string client_secret, string code)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation($"User with ID {user.Id} is syncing a strava account client_id:{client_id} client_secret{client_secret} code{code}");


            var adpDictionary = _db.ActivityDataProviders.ToList().ToDictionary(adp => adp.Id);
            var currentActivityAccounts = _db.ActivityAccounts.Where(aa => aa.UserId == user.Id).ToList();

            var strava = adpDictionary[ActivityDataProviderIds.Strava];
            var activityAccount = new ActivityAccount()
            {
                ActivityDataProvider = strava,
                ActivityDataProviderId = strava.Id,
                SourceKey = code,
                DateAdded = DateTime.Now,
                UserId = user.Id
            };

            _db.ActivityAccounts.Add(activityAccount);
            _db.SaveChanges();

            var model = new AthleteOverviewViewModel();
            model.ActivityAccounts = currentActivityAccounts;
            model.ActivityDataProviders = adpDictionary;
            model.ActivityAccounts.Add(activityAccount);
            return View(nameof(AthleteOverview), model);
        }
    }
}
