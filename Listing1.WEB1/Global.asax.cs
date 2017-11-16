using AutoMapper;
using Listing1.WEB;
using Listing1.WEB.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
namespace Listing1.WEB1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AutoFac
            Bootstrapper.Run();

            //AutoMapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
