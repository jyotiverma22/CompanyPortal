using CompanyPortal.ViewModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var token = Session["token"];
            if (token == null)
            {
                ViewBag.Message = null;
                return View();
            }
            else
                return RedirectToAction("Index", "LoggedIn");

        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    UriBuilder builder = new UriBuilder(ConfigurationManager.AppSettings["baseUrl"]);
                    var json = JsonConvert.SerializeObject(loginViewModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resultpost = await client.PostAsync(builder.Uri + "/CheckUser", content);
                    if (resultpost.IsSuccessStatusCode)
                    {
                        if (Convert.ToBoolean(resultpost.Content.ReadAsStringAsync().Result))
                        {
                            //user Exist, generate the token 

                            using (HttpClient httpclient = new HttpClient())
                            {
                                UriBuilder uri = new UriBuilder("http://localhost:61488/token");
                                var data = new Dictionary<string, string>
                                {
                                     {"grant_type", "password"},
                                     {"username", loginViewModel.Username},
                                     {"password", loginViewModel.Password},
                                };

                                var tokenResponse = client.PostAsync(uri.Uri, new FormUrlEncodedContent(data)).Result;

                                if (tokenResponse.IsSuccessStatusCode)
                                {
                                    
                                    var response = (JObject)JsonConvert.DeserializeObject(tokenResponse.Content.ReadAsStringAsync().Result);
                                    Session["token"] = response["access_token"].Value<string>();
                                    var p = response["access_token"].Value<string>();
                                    Session["username"] = loginViewModel.Username;
                                    return RedirectToAction("Index", "LoggedIn", new { loginViewModel.Username });
                                    
                                }

                            }



                        }

                        else
                        {
                            //user does not exist
                            ModelState.AddModelError("", "Username/Password Incorrect");
                            //         return PartialView("Login", loginViewModel);
                            ModelState.Clear();
                        }

                    }

                }
            }

            ViewBag.Message = "Username/Password Incorrect";
            return View();

        }

        public ActionResult RegisterUser()
        {
            return PartialView(new RegisterViewModel());
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

                   // client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
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

                                   return RedirectToAction("Index");
                                  

                                 
                                }
                            }


                        }

                    }
                    else
                    {
                        Console.WriteLine("Error ");

                    }

                }
                
            }

            return PartialView(registerViewModel);
        }

      


        private  int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }


        public ActionResult LogOut()
        {
            Session["token"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
