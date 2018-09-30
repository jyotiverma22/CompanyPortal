using CompanyPortal.ViewModels;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;



namespace CompanyPortal.Controllers
{
    public class ProjectJQGridController : Controller
    {
        //get the values in jqgrid
        /// <summary>
        /// get the projects from data base and pass it into the jq grid
        /// </summary>
        /// <param name="sidx"> sorting index</param>
        /// <param name="sord">sorting order</param>
        /// <param name="rows"> number of rows appeared in jqgrid</param>
        /// <param name="page">number of pages</param>
        /// <returns></returns>
        
        
        public JsonResult GetProjects(JQGridParameter jQGridParameter,string status)
       {
            jQGridParameter.SortBy = (jQGridParameter.SortBy==null)? "project_name" : jQGridParameter.SortBy;
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "asc" : jQGridParameter.OrderBy;
            jQGridParameter.Rows = 5;
            jQGridParameter.Page = 1;
            var token = Session["token"];
            var username = Session["username"];
            jQGridParameter.OrderBy = (jQGridParameter.OrderBy == null) ? "" : jQGridParameter.OrderBy;
            int PageIndex = Convert.ToInt32(jQGridParameter.Page) - 1;
            int pagesize = jQGridParameter.Rows;
            var list = new List<ProjectViewModel>();
            var templist = new List<ProjectViewModel>();
            //Retrieving the data from the server
            using (HttpClient client = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                //  url.Query = "username=" + username;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

                var result = client.GetAsync(url.Uri + "/getProjectDetails?username=" + username+"&status="+status).Result;
                if (result.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<List<ProjectViewModel>>(result.Content.ReadAsStringAsync().Result);

                }
                else
                {
                }

            }


            //searching from the list
            if (jQGridParameter._search)
            {
                /* switch (jQGridParameter.SearchField)
                 {
                     case "Project_Name":
                         list = list.Where(t => t.Project_Name.Contains(jQGridParameter.SearchString)).ToList();
                         break;
                     case "Mgr_Id":
                         list = list.Where(t => t.Mgr_Id.Contains(jQGridParameter.SearchString)).ToList();
                         break;
                 }*/

                if (jQGridParameter.filters.groupOp == "AND")
                {
                    foreach(var rule in jQGridParameter.filters.rules)
                    {

                        switch(rule.field)
                        {
                            case "Project_Name":
                                list = list.Where(t => t.Project_Name.Contains(rule.data)).ToList();
                                break;
                            case "Mgr_Id":
                                list = list.Where(t => t.Mgr_Id.Contains(rule.data)).ToList();
                                break;
                        }
                    }
                }
                else if(jQGridParameter.filters.groupOp=="OR")
                {

                    foreach(var rule in jQGridParameter.filters.rules)
                    {
                        List<ProjectViewModel> temp;
                        switch (rule.field)
                        {
                            case "Project_Name":
                                temp = list.Where(t => t.Project_Name.Contains(rule.data??"")).ToList();
                                templist = templist.Concat(temp).ToList();
                                break;
                            case "Mgr_Id":
                                temp = list.Where(t => t.Mgr_Id.Contains(rule.data??"")).ToList();
                                templist = templist.Concat(temp).ToList();
                                break;
                        }
                    }
                    list = templist.Distinct().ToList();
                }
             


            }

            //sorting and page size
            int totalRecords = list.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)jQGridParameter.Rows);

            

            // sorting of the data
            switch (jQGridParameter.SortBy.ToLower())
            {
                case "project_name":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        list = list.OrderByDescending(t => t.Project_Name).ToList();
                        list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        list = list.OrderBy(t => t.Project_Name).ToList();
                        list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }

                    break;
                case "manager_name":
                    if (jQGridParameter.OrderBy.ToUpper() == "DESC")
                    {
                        list = list.OrderByDescending(t => t.Mgr_Id).ToList();
                        list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();
                    }
                    else
                    {
                        list = list.OrderBy(t => t.Mgr_Id).ToList();
                        list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();

                    }

                    break;

            }



            var jsondata = new
            {
                total = totalPages,
                jQGridParameter.Page,
                records = totalRecords,
                rows = list
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// function for getting the team details of a particular project
        /// </summary>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public JsonResult getTeamDetails(string sidx, string sord, int rows, int page, int pid)
        {
            var token = Session["token"];
            var username = Session["username"];
            sord = (sord == null) ? "" : sord;
            int PageIndex = Convert.ToInt32(page) - 1;
            int pagesize = rows;
            var list = new List<RegisterViewModel>();
            using (HttpClient client = new HttpClient())
            {
                UriBuilder url = new UriBuilder(ConfigurationManager.AppSettings["detailsUrl"]);
                //  url.Query = "username=" + username;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

                var result = client.GetAsync(url.Uri + "/getTeamDetails?pid=" + pid).Result;
                if (result.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<List<RegisterViewModel>>(result.Content.ReadAsStringAsync().Result);

                }
                else
                {
                }

            }


            int totalRecords = list.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                list = list.OrderByDescending(t => t.userId).ToList();
                list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();
            }
            else
            {
                list = list.OrderBy(t => t.userId).ToList();
                list = list.Skip(PageIndex * pagesize).Take(pagesize).ToList();

            }

            var jsondata = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = list
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

    }
}
