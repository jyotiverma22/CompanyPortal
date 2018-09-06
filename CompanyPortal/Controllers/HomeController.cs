using CompanyPortal.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<ActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            int age = CalculateAge(Convert.ToDateTime(registerViewModel.DOB));

            if(age<20)
            {
                
                ModelState.AddModelError("DOB","Age must be 20 or more");

            }



            if (ModelState.IsValid)
            {
                //get User Id
                string userId;
                using (HttpClient client = new HttpClient())
                {
                    UriBuilder builder = new UriBuilder(ConfigurationManager.AppSettings["baseUrl"]);

                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
                    var result = client.GetAsync(builder.Uri+"/GetUserId").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        userId = await result.Content.ReadAsStringAsync();
                        userId = userId.Replace('"', ' ').Trim();
                        registerViewModel.userId = userId;

                        //Now save the data into the database

                        using (HttpClient httpclient = new HttpClient())
                        {
                            var json = JsonConvert.SerializeObject(registerViewModel);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                           // httpclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
                            var resultpost = await client.PostAsync(builder.Uri+"/saveuserDetails", content);
                            if(resultpost.IsSuccessStatusCode)
                            {
                                if(Convert.ToBoolean(resultpost.Content.ReadAsStringAsync().Result))
                                {

                                    Console.WriteLine("User Added");

                                    RedirectToAction("Login");
                                    //Now Generate Token

                                 /*   using (HttpClient httpc = new HttpClient())
                                    {
                                     //   httpc.BaseAddress= new Uri("http://localhost:61488/token");

                                    }*/
                                }
                            }


                        }

                    }
                    else
                    {
                        Console.WriteLine("Error ");

                    }

                }





                // save data into database




                //generate token







            }

            return View(registerViewModel);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }

        private  int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
