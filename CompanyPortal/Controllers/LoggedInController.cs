using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class LoggedInController : Controller
    {
        // GET: LoggedIn
        public ActionResult Index()
        {
                return View();
        }
    }
}