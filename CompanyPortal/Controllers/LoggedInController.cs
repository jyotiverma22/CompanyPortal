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
using System.IO;
using Models;
using System.Text;

namespace CompanyPortal.Controllers
{
    //MVC controller after the user logged  in
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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                    //  url.Query = "username=" + username;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

                    var result = client.GetAsync(url.Uri + "/getemployeedetails?username=" + username).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        employees = JsonConvert.DeserializeObject<EmployeeDetailsViewModel>(result.Content.ReadAsStringAsync().Result);
                        return PartialView("_EmployeeDetails", employees);

                    }
                    else
                    {
                        Session["token"]=null;
                        return RedirectToAction("Index", "home");

                    }

                }
            }
            catch(Exception e)
            {
                //Token authentication time out
                string path = ConfigurationManager.AppSettings["logPath"].ToString();
                 
               if(System.IO.File.Exists(path))
                {
                    //Error logging into the log file 
                    StreamWriter sw = new StreamWriter(path);
                    sw.Write("\nToken authentication expired ");
                    sw.Write("\nType of exception  "+e.GetType().Name);
                    sw.Write("\nMessage "+e.Message);

                    DbLogging dbLogging = new DbLogging {
                        ExceptionMessage = e.Message.ToString(),
                        ExceptionType = e.GetType().Name.ToString(),
                        ExceptionSource = e.StackTrace.ToString(),
                        ExceptionUrl = ConfigurationManager.AppSettings["detailsUrl"] + "/ getemployeedetails ? username = " + username,
                        LogDate = DateTime.Now
                        };

                    //Error logging into the Database
                    using (HttpClient httpclient = new HttpClient())
                    {
                        UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["baseUrl"]);
                        var json = JsonConvert.SerializeObject(dbLogging);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var result =httpclient.PostAsync(url.Uri + "SaveErrorLoggingDetails",content).Result;

                        if(result.IsSuccessStatusCode)
                        {
                             //Exception written into the database
                        }
                        else { //error in writing the exception into the database
                        }



                    }

                }
                else
                {

                }

                Session["token"] = null;
                return RedirectToAction("Index", "home");
            }



          }
        

        //working on this part- this function is not complete
        [HttpGet]
        public ActionResult EditProjectDetails()
        {
            return PartialView("_EditProjectDetails",new ProjectViewModel());
        }

        //working on this part- this function is not complete
        [HttpPost]
        public ActionResult EditProjectDetails(ProjectViewModel projectViewModel)
        {
            return null;
        }

        [HttpGet]
        public ActionResult AddProject()
        {

            return PartialView("_AddProjectPartialView");
        }


        [HttpPost]
        public ActionResult AddProject(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient httpclient = new HttpClient())
                {
                    UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                    var json = JsonConvert.SerializeObject(projectViewModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = httpclient.PostAsync(url.Uri + "/AddProjectDetails", content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return Json(Convert.ToInt32(result.Content.ReadAsStringAsync().Result));
                      //  return Json(new { data = projectViewModel }, JsonRequestBehavior.AllowGet); ;
                    }
                    else
                    {

                    }

                }
            }
            return Json(false);
           // return PartialView("_AddProjectPartialView", projectViewModel);
        }

    }
}