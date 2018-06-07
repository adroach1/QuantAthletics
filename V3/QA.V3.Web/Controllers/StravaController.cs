using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QA.V3.Web.Models;
using QA.V3.Web.Models.ManageViewModels;
using QA.V3.Web.Services;

namespace QA.V3.Web.Controllers
{
    public class StravaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public StravaController(UserManager<ApplicationUser> userManager, ILogger<StravaController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        //[HttpGet]
        //public async Task<IActionResult> ViewStravaAccount()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    _logger.LogInformation("User with ID {UserId} is interested in syncing a strava account", user.Id);
        //    var model = new SyncStravaAccountViewModel();
        //    return View(nameof(ViewStravaAccount), model);
        //}


        //moved to athlete controler
        /// <summary>
        /// URL that is called after a user has approved access for our application.
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// see http://developers.strava.com/docs/authentication/
        //[HttpGet]
        ////https://localhost:44353/strava/stravatokenexchange?state=default%29&code=1c988491eac6289ce9ca9133a0466f4aed547856&scope=public
        //public async Task<IActionResult> StravaTokenExchange(string client_id, string client_secret, string code)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    _logger.LogInformation($"User with ID {user.Id} is syncing a strava account client_id:{client_id} client_secret{client_secret} code{code}");
        //    var model = new SyncStravaAccountViewModel();
        //    return View("SyncStravaAccount", model);
        //}

    }
}