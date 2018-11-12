using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CompanyPortal.JobScheduling
{
    public class JobClass : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UriBuilder builder = new UriBuilder(ConfigurationManager.AppSettings["baseUrl"]);
                var content = new StringContent("", Encoding.UTF8, "application/json");
                var resultpost = httpClient.PostAsync(builder.Uri + "/SetAllEmployeesAttendence", content).Result;
            }
            return null;
        }

      
    }
}