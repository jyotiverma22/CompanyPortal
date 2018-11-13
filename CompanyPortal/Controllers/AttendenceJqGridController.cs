using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class AttendenceJqGridController : Controller
    {
        public JsonResult GetAttendence(JQGridParameter jQGridParameter,string userid)
        {
            jQGridParameter.SortBy = (jQGridParameter.SortBy == null) ? "Date" : jQGridParameter.SortBy;
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "asc" : jQGridParameter.OrderBy;
            jQGridParameter.Rows = (jQGridParameter.Rows == 0) ? 20 : jQGridParameter.Rows;
            jQGridParameter.Page = (jQGridParameter.Page == 0) ? 1 : jQGridParameter.Page;
            jQGridParameter.SearchValue = (jQGridParameter.SearchValue == null) ? "" : jQGridParameter.SearchValue;
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "" : jQGridParameter.OrderBy;
            int PageIndex = Convert.ToInt32(jQGridParameter.Page) - 1;
            int pagesize = jQGridParameter.Rows;

            List<Attendence> AttendenceList = new List<Attendence>();
            using (HttpClient httpClient = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                var result = httpClient.GetAsync(url.Uri + "/GetAttendence?UserId=" + userid ).Result;
                if (result.IsSuccessStatusCode)
                {
                    AttendenceList = JsonConvert.DeserializeObject<List<Attendence>>(result.Content.ReadAsStringAsync().Result);

                }

            }
            //if (jQGridParameter.Search)
            //{
            //    AttendenceList = AttendenceList.Where(t => (t.Date.Contains(jQGridParameter.SearchValue)) || (t.Mgr_Id.Contains(jQGridParameter.SearchValue))).ToList();
            //}


            //sorting and page size
            int totalRecords = AttendenceList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)jQGridParameter.Rows);

            // sorting of the data
            switch (jQGridParameter.SortBy.ToLower())
            {
                case "date":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        AttendenceList = AttendenceList.OrderByDescending(t => t.Date).ToList();
                        AttendenceList = AttendenceList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        AttendenceList = AttendenceList.OrderBy(t => t.Date).ToList();
                        AttendenceList = AttendenceList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }

                    break;
                case "attendencestatus":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        AttendenceList = AttendenceList.OrderByDescending(t => t.AttendenceStatus).ToList();
                        AttendenceList = AttendenceList.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        AttendenceList = AttendenceList.OrderBy(t => t.AttendenceStatus).ToList();
                        AttendenceList = AttendenceList.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }

                    break;

            }

            var jsondata = new
            {
                total = totalPages,
                jQGridParameter.Page,
                records = totalRecords,
                rows = AttendenceList
            };


            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }
}
