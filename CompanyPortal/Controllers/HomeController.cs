using CompanyPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {

            }
            return View(registerViewModel);
        }

    }
}
