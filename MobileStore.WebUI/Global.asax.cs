using MobileStore.Domain.Concrete;
using MobileStore.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobileStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());


            //h ttps://stackoverflow.com/questions/3552000/entity-framework-code-only-error-the-model-backing-the-context-has-changed-sinc
            Database.SetInitializer<EFDbContext>(null);
        }
    }
}
