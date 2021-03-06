﻿using CompanyPortal.JobScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CompanyPortal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            JobScheduler.Start();
        }


        protected void Session_OnStart()
        {
            Session["username"]=null;
            Session["token"]=null;
            Session["role"] = null;
            Session["firstname"] = null;
            Session["dept"] = null;
            Session["id"] = null;

        }
    }
}
