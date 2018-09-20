using CompanyPortal.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    
    public class LoggedInController : Controller
    {
        
        // GET: LoggedIn
        /// <summary>
        /// if user logged in then dashboard appears
        /// otherwiser home page appears
        /// </summary>
        /// <returns>
        /// returns view
        /// </returns>
        public ActionResult Index()
        {
            var token = Session["token"];
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        /// <summary>
        /// Return the Member Partial View that shows the sidenav and memeber dashboard
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberPartial()
        {
            return PartialView("_MemberPartialView");
        }
        /// <summary>
        /// shows the project manager partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjManagerPartial()
        {
            return PartialView("_ProjManagerPartialView");
        }

        /// <summary>
        /// shows the reporting manager partial view 
        /// </summary>
        /// <returns></returns>
        public ActionResult RepManagerPartial()
        {
            return PartialView("_RepManagerPartialView");
        }


        /// <summary>
        /// shows the admin partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminPartial()
        {
            return PartialView("_AdminPartialView");
        }

        /// <summary>
        /// renders the partial view of the project details 
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectDetails(string projectType)
        {
            return PartialView("_ProjectDetails",projectType);
        }

        /// <summary>
        /// retrives the values from database then 
        /// pass the model to the partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeDetails(string userid)
        {

            EmployeeDetailsViewModel employees = new EmployeeDetailsViewModel();
            var token = Session["token"];
            var username =(userid!=null)?userid: Session["username"];
            if (token == null)
            {
                return RedirectToAction("Index", "home");
            }
            using (HttpClient client = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                //  url.Query = "username=" + username;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

                var result = client.GetAsync(url.Uri + "/getemployeedetails?username=" + username).Result;
                if (result.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<EmployeeDetailsViewModel>(result.Content.ReadAsStringAsync().Result);
                    return PartialView("_EmployeeDetails",employees);

                }
                else
                {
                    return RedirectToAction("Index", "home");

                }

            }

          }


    

    }
}