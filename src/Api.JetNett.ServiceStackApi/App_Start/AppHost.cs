using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using Api.JetNett.Models.Types;
using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi.App_Start
{
    public static class AppHostCommon
    {
        public static void Init(Container container, string connectionString)
        {
            var dbConnectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            container.Register<IDbConnectionFactory>(dbConnectionFactory);
            container.Register<ICacheClient>(new MemoryCacheClient());

            //user auth testing
            var userRepo = new InMemoryAuthRepository();

            string hash;
            string salt;
            new SaltedHash().GetHashAndSaltString("ssapi", out hash, out salt);
            userRepo.CreateUserAuth(new UserAuth
            {
                Id = 1,
                DisplayName = "Api User",
                Email = "jetnettone@gmail.com",
                UserName = "ApiUser",
                FirstName = "Api",
                LastName = "User",
                PasswordHash = hash,
                Salt = salt
            }, "ssapi");

            container.Register<IUserAuthRepository>(userRepo);
        }

        public static IEnumerable<IPlugin> GetPlugins()
        {
            yield return new CorsFeature();
            yield return new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] { new BasicAuthProvider() });
        }
    }
    public class WebAppHost : AppHostHttpListenerBase
    {
        private string ConnectionString { get; set; } 

        public WebAppHost(string connString) : base("JetNett Api Service", typeof (WebAppHost).Assembly)
        {
            ConnectionString  = connString;
        }

        public override void Configure(Container container)
        {
            //Configure our application
            AppHostCommon.Init(container, ConnectionString);

            this.Plugins.AddRange(AppHostCommon.GetPlugins());

            Routes
                .Add<BadLink>("/badLink", "POST, PUT, PATCH, DELETE")
                .Add<Client>("/client", "POST, PUT, PATCH, DELETE")
                .Add<AdGroup>("/adGroup", "POST, PUT, PATCH, DELETE")
                .Add<Link>("/links", "POST, PUT, PATCH, DELETE")
                .Add<CommunityZipcodes>("/zipcode", "POST, PUT, PATCH, DELETE")
                .Add<Folder>("/folder", "POST, PUT, PATCH, DELETE")
                .Add<Page>("/page", "POST, PUT, PATCH, DELETE")
                .Add<MetroiLinks>("/metroilinks", "POST, PUT, PATCH, DELETE");
        }
    }

    public class SelfAppHost : AppHostHttpListenerBase
    {
        protected string ConnectionString { get; private set; }
        public SelfAppHost(string connString) : base("Test Service", typeof (WebAppHost).Assembly)
        {
            ConnectionString = connString;
        }

        public override void Configure(Container container)
        {
            AppHostCommon.Init(container, this.ConnectionString);

            this.Plugins.AddRange(AppHostCommon.GetPlugins());
        }
    }

}