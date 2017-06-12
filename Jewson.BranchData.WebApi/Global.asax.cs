using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Jewson.BranchData.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents(); // Register Unity for Dependency Injection
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
