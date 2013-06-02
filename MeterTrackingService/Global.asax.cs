using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MeterTrackingService
{
    public class Global : System.Web.HttpApplication
    {
        public class MeterTrackingAppHost : AppHostBase
        {
            public MeterTrackingAppHost() : base("Meter Tracking", typeof(MeterService).Assembly)
            {
            }

            public override void Configure(Funq.Container container)
            {
                // Configure our application
            }


        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new MeterTrackingAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}