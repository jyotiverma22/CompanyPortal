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
        public ActionResult Index()
        {
            EmployeeDetailsViewModel employees = new EmployeeDetailsViewModel();
            var token = Session["token"];
            var username = Session["username"];
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
                if(result.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<EmployeeDetailsViewModel>(result.Content.ReadAsStringAsync().Result);
                    return View(employees);

                }
                else
                {
                    return RedirectToAction("Index", "home");

                }

            }

        }


        public ActionResult Project()
        {
            return View();
        }

    }
}