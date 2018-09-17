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
            var token = Session["token"];
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult ProjectDetails()
        {
            return PartialView("_ProjectDetails", new ProjectViewModel());
        }

        public ActionResult EmployeeDetails()
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


        //get the values in jqgrid

        public JsonResult GetProjects(string sidx, string sord,int rows, int page)
        {
            var token = Session["token"];
            var username = Session["username"];

            sord = (sord == null) ? "" : sord;
            int PageIndex = Convert.ToInt32(page) - 1;
            int pagesize = rows;
            var list = new List<ProjectViewModel>();
            using (HttpClient client = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                //  url.Query = "username=" + username;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

                var result = client.GetAsync(url.Uri + "/getProjectDetails?username=" + username).Result;
                if (result.IsSuccessStatusCode)
                {
                     list = JsonConvert.DeserializeObject<List<ProjectViewModel>>(result.Content.ReadAsStringAsync().Result);
                  
                }
                else
                {
                }

            }


            int totalRecords = list.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if(sord.ToUpper()=="DESC")
            {
                list = list.OrderByDescending(t => t.Project_Name).ToList();
                list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();
            }
            else
            {
                list = list.OrderBy(t => t.Project_Name).ToList();
                list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();

            }

            var jsondata = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = list
            };
            return Json(jsondata,JsonRequestBehavior.AllowGet);

        }


    }
}