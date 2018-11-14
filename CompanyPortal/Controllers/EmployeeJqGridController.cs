using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class EmployeeJqGridController : Controller
    {
        // GET: EmployeeJqGrid
        public ActionResult GetEmployees(JQGridParameter jQGridParameter)
        {
            jQGridParameter.SortBy = (jQGridParameter.SortBy == null) ? "Date" : jQGridParameter.SortBy;
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "asc" : jQGridParameter.OrderBy;
            jQGridParameter.Rows = (jQGridParameter.Rows == 0) ? 20 : jQGridParameter.Rows;
            jQGridParameter.Page = (jQGridParameter.Page == 0) ? 1 : jQGridParameter.Page;
            jQGridParameter.SearchValue = (jQGridParameter.SearchValue == null) ? "" : jQGridParameter.SearchValue;
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "" : jQGridParameter.OrderBy;
            int PageIndex = Convert.ToInt32(jQGridParameter.Page) - 1;
            int pagesize = jQGridParameter.Rows;

            List<Employee> EmployeeList = new List<Employee>();
            using (HttpClient httpClient = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                var result = httpClient.GetAsync(url.Uri + "/GetEmployeeDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(result.Content.ReadAsStringAsync().Result);

                }

            }
            if (jQGridParameter.Search)
            {
                EmployeeList = EmployeeList.Where(t => (t.JoiningDate.ToShortDateString().Contains(jQGridParameter.SearchValue)) || (t.FullName.Contains(jQGridParameter.SearchValue)) || (t.Email.Contains(jQGridParameter.SearchValue)) || (t.UserId.Contains(jQGridParameter.SearchValue))).ToList();
            }


            //sorting and page size
            int totalRecords = EmployeeList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)jQGridParameter.Rows);

            // sorting of the data
            switch (jQGridParameter.SortBy.ToLower())
            {
                case "fullname":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        EmployeeList = EmployeeList.OrderByDescending(t => t.FullName).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        EmployeeList = EmployeeList.OrderBy(t => t.FullName).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }

                    break;
                case "joiningdate":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        EmployeeList = EmployeeList.OrderByDescending(t => t.JoiningDate).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        EmployeeList = EmployeeList.OrderBy(t => t.JoiningDate).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }
                

                    break;
                case "userid":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        EmployeeList = EmployeeList.OrderByDescending(t => t.UserId).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        EmployeeList = EmployeeList.OrderBy(t => t.UserId).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }


                    break;
                case "email":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        EmployeeList = EmployeeList.OrderByDescending(t => t.Email).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        EmployeeList = EmployeeList.OrderBy(t => t.Email).ToList();
                        EmployeeList = EmployeeList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }
                    break;

            }

            var jsondata = new
            {
                total = totalPages,
                jQGridParameter.Page,
                records = totalRecords,
                rows = EmployeeList
            };


            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }
}