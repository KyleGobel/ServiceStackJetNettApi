using System;
using System.Configuration;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace Api.JetNett.ServiceStackApi
{
    public class Global : System.Web.HttpApplication
    {
        public class ApiAppHost : AppHostHttpListenerBase        {
            public ApiAppHost() : base("JetNett Api Service", typeof(ApiAppHost).Assembly)
            {}

            public override void Configure(Funq.Container container)
            {
                //Configure our application
                const string localConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=DailyEZDevelopment;Integrated Security=True";
                var connectionString = ConfigurationManager.ConnectionStrings["azureJetnettConnectionString"].ConnectionString;
                var dbConnectionFactory = new OrmLiteConnectionFactory(connectionString,
                    SqlServerDialect.Provider);

                //Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                //    new IAuthProvider[] {
                //        new BasicAuthProvider()
                //    }));

                Plugins.Add(new CorsFeature());
                //container.Register<ICacheClient>(new MemoryCacheClient());

                //var userRepo = new InMemoryAuthRepository();
                //container.Register<IUserAuthRepository>(userRepo);
                container.Register<IDbConnectionFactory>(dbConnectionFactory);

                //string hash;
                //string salt;

                //new SaltedHash().GetHashAndSaltString("ssapi", out hash, out salt);

                //userRepo.CreateUserAuth(new UserAuth {
                //    Id = 1,
                //    DisplayName = "Api User",
                //    Email = "jetnettone@gmail.com",
                //    UserName = "ApiUser",
                //    FirstName = "Api",
                //    LastName = "User",
                //    PasswordHash = hash,
                //    Salt = salt
                //}, "ssapi");
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