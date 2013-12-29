using System.Collections.Generic;
using System.Data;
using Api.JetNett.Models.Types;
using ServiceStack.Data;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Api.JetNett.ServiceStackApi.Facts.Setup
{
    public class Db
    {
        public IDbConnectionFactory ConnectionFactory { get; private set; }
        public List<Folder> SeedFolders { get; private set; }
        public List<Page> SeedPages { get; private set; }
        public List<Client> SeedClients { get; private set; } 
        public List<Link> SeedLinks { get; private set; } 

        public List<MetroiLinks> SeedMetroiLinks { get; private set; } 
        public void SetupDatabase()
        {
            OrmLiteConfig.DialectProvider = SqlServerOrmLiteDialectProvider.Instance;
            this.ConnectionFactory = new OrmLiteConnectionFactory(TestConfig.ConnectionString);
            this.SetupTestDb();
        }
        private void SetupTestDb()
        {
            LogManager.LogFactory = new DebugLogFactory();

            using (var db = ConnectionFactory.OpenDbConnection())
            {
                db.DropTable<MetroiLinks>();
                db.DropTable<Client>();
                db.DropTable<Link>();
                db.DropTable<Page>();
                db.DropTable<Folder>();
                db.CreateTable<Folder>();
                db.CreateTable<Page>();
                db.CreateTable<Link>();
                db.CreateTable<Client>();
                db.CreateTable<MetroiLinks>();

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

            var page1 = new Page { FolderId = 2, Title = "Page with Links" };
            var pageId = (int)db.Insert(page1, true);
            page1.Id = pageId;

            var page2 = new Page { FolderId = 1, Title = "Page With Links in Folder 1" };
            var secondPageId = (int)db.Insert(page2, true);
            page2.Id = secondPageId;

            SeedPages.Add(page1);
            SeedPages.Add(page2);


            SeedLinks = new List<Link>
            {
                new Link {Id = 1, IsLink = true, PageId = pageId, Position = 1, Title= "Test Link 1", Url= "http://www.jetnett.com"},
                new Link {Id = 2, IsLink = true, PageId = pageId, Position = 2, Title= "Test Link 2", Url= "http://www.jetnett.com"},
                new Link {Id = 3, IsLink = true, PageId = pageId, Position = 3, Title= "Test Link 3", Url= "http://www.jetnett.com"},
                new Link {Id = 4, IsLink = true, PageId = pageId, Position = 4, Title= "Test Link 4", Url= "http://www.jetnett.com"},
                new Link {Id = 5, IsLink = true, PageId = pageId, Position = 5, Title= "Test Link 5", Url= "http://www.kylegobel.com"},
                new Link {Id = 6, IsLink = true, PageId = pageId, Position = 6, Title= "Test Link 6", Url= "http://www.jetnett.com"},
                new Link {Id = 7, IsLink = true, PageId = secondPageId, Position = 1, Title= "Test Link 1", Url= "http://www.jetnett.com"},
                new Link {Id = 8, IsLink = true, PageId = secondPageId, Position = 2, Title= "Test Link 2", Url= "http://www.jetnett.com"},
                new Link {Id = 9, IsLink = true, PageId = secondPageId, Position = 3, Title= "Test Link 3", Url= "http://www.jetnett.com"},
                new Link {Id = 10, IsLink = true, PageId = secondPageId, Position = 4, Title= "Test Link 4", Url= "http://www.jetnett.com"},
                new Link {Id = 11, IsLink = true, PageId = secondPageId, Position = 5, Title= "Test Link 5", Url= "http://www.jetnett.com"},
            };

            db.InsertAll(SeedLinks);


            SeedClients = new List<Client>
            {
                new Client { Id = 1, Name = "Client A", UserId= "admin", Password = "password"},
                new Client { Id = 2, Name = "Client B", UserId = "user", Password = "pass" }
            };

            db.InsertAll(SeedClients);

            SeedMetroiLinks = new List<MetroiLinks>
            {
                new MetroiLinks { Id =1, ClientId = 1},
                new MetroiLinks { Id = 2, ClientId = 2}
            };
            db.InsertAll(SeedMetroiLinks);
        }
    }
}