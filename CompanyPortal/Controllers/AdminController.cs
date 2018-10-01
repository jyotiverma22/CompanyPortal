using CompanyPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProjectDetails()
        {
            return PartialView("_AddProjectPartialView");
        }


        [HttpPost]
        public ActionResult AddProjectDetails(ProjectViewModel projectViewModel)
        {
            return PartialView("_AddProjectPartialView");
        }
    }
}