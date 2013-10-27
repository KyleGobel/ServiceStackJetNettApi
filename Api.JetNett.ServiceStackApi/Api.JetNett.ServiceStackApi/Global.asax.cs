using System;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;

namespace Api.JetNett.ServiceStackApi
{
    public class Global : System.Web.HttpApplication
    {
        public class ApiAppHost : AppHostBase
        {
            public ApiAppHost() : base("JetNett Api Service", typeof(ApiAppHost).Assembly)
            {}

            public override void Configure(Funq.Container container)
            {
                //Configure our application
                const string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=DailyEZDevelopment;Integrated Security=True";
                var dbConnectionFactory = new OrmLiteConnectionFactory(connectionString,
                    SqlServerDialect.Provider);

                container.Register<IDbConnectionFactory>(dbConnectionFactory);
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new ApiAppHost().Init();
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