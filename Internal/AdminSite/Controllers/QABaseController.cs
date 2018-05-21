using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AdminSite.Settings;
using NLog;

namespace AdminSite.Controllers
{
    public class QaBaseController: ApiController
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();
    }
}