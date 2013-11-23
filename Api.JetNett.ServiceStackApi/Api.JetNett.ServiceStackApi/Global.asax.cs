using System;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.Cors;
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
                const string localConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=DailyEZDevelopment;Integrated Security=True";
                const string connectionString = @"Server=tcp:ogt6gud01l.database.windows.net,1433;Database=Jetnett_Data;User ID=jetnett_admin@ogt6gud01l;Password=Mad15onmetr0;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                var dbConnectionFactory = new OrmLiteConnectionFactory(connectionString,
                    SqlServerDialect.Provider);

                Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                    new IAuthProvider[] {
                        new BasicAuthProvider()
                    }));

                Plugins.Add(new CorsFeature());
                container.Register<ICacheClient>(new MemoryCacheClient());

                var userRepo = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepo);
                container.Register<IDbConnectionFactory>(dbConnectionFactory);

                string hash;
                string salt;

                new SaltedHash().GetHashAndSaltString("ssapi", out hash, out salt);

                userRepo.CreateUserAuth(new UserAuth {
                    Id = 1,
                    DisplayName = "Api User",
                    Email = "jetnettone@gmail.com",
                    UserName = "ApiUser",
                    FirstName = "Api",
                    LastName = "User",
                    PasswordHash = hash,
                    Salt = salt
                }, "ssapi");
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