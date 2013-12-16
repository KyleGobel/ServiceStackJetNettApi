using System;
using System.Collections.Generic;
using System.Data;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.App_Start;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Api.JetNett.ServiceStackApi.Facts.Setup
{
    public class TestDb : IDisposable
    {
        protected SelfAppHost AppHost { get; private set; }
        public IDbConnectionFactory ConnectionFactory { get; private set; }
        public List<Folder> SeedFolders { get; private set; }
        public List<Page> SeedPages { get; private set; }
        public TestDb()
        {
            OrmLiteConfig.DialectProvider = SqlServerOrmLiteDialectProvider.Instance;
            this.ConnectionFactory = new OrmLiteConnectionFactory(TestConfig.ConnectionString);
            this.SetupTestDb();

            
            AppHost = new SelfAppHost(TestConfig.ConnectionString);
            AppHost.Init();
            AppHost.Start("http://localhost:" + TestConfig.TestServicePort + "/");
        }

        private void SetupTestDb()
        {
            using (var db = ConnectionFactory.OpenDbConnection())
            {
                db.DropAndCreateTable<Folder>(); 
                db.DropAndCreateTable<Page>();

                Seed(db);
            }
        }
        private void Seed(IDbConnection db)
        {
            SeedFolders = new List<Folder>
            {
                new Folder {Id = 1, Name = "Wisconsin", ParentFolderId = null},
                new Folder {Id = 2, Name = "Dane County", ParentFolderId = 1}
            };

            SeedPages = new List<Page>
            {
                new Page {Id = 1, FolderId = 1, Title = "WI Base Page 1"},
                new Page {Id = 2, FolderId = 1, Title = "WI Base Page 2"},
                new Page {Id = 3, FolderId = 2, Title = "Belleville, WI"},
                new Page {Id = 4, FolderId = 2, Title = "Madison, WI"}
            };

            db.InsertAll(SeedFolders);
            db.InsertAll(SeedPages);
        }
        public void Dispose()
        {
            AppHost.Stop();
            AppHost.Dispose();
        }
    }
}