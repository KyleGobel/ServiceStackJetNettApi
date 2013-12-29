using System;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using Xunit;

    public class LinksServiceFacts 
    {
        protected Db Database { get; set; }
        protected LinksService LinksService { get; set; }
        public LinksServiceFacts()
        {
            Database = new Db();
            Database.SetupDatabase();

            LinksService = new LinksService(Database.ConnectionFactory);
        }

        public class TheGetMethod
        {
            public class ListLinksRequestOverload : LinksServiceFacts
            {
                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Link")]
                public void ReturnsAllLinks_WhenCalledWithEmptyListRequest()
                {
                    
                    var results = LinksService.Get(new ListLinksRequest());
                    Assert.Equal(Database.SeedLinks, results);
                }

                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Link")]
                public void ReturnsLinks_WhenCalledWithListOfIds()
                {
                    var link = Database.SeedLinks[0];
                    var results = LinksService.Get(new ListLinksRequest() { Ids = link.Id.ToEnumerable().ToArray() });

                    Assert.Equal(1, results.Count);
                    Assert.Equal(link, results[0]);
                }

                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Link")]
                public void ReturnsLinksOnPage_WhenCalledWithPageId()
                {
                    var page = Database.SeedPages.Last();
                    var results = LinksService.Get(new ListLinksRequest() { PageId = page.Id });

                    Assert.Equal(results, Database.SeedLinks.Where(x => x.PageId == page.Id));
                }
            }

            public class GetLinksRequestOverload : LinksServiceFacts
            {
                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Link")]
                public void ReturnsLinkWithIdGivenToRequest()
                {
                    var result = LinksService.Get(new GetLinkRequest(Database.SeedLinks[0].Id));

                    Assert.Equal(Database.SeedLinks[0], result);
                }
            }
        }

        public class ThePutMethod : LinksServiceFacts
        {
            [Fact]
            [Trait("Verb", "PUT")]
            [Trait("ServiceTest", "Link")]
            public void UpdatesAFolder()
            {
                const string newName = "An updated name";
                var link = Database.SeedLinks[0];
                link.Title = newName;
                LinksService.Put(new UpdateLinkRequest(link));


                Assert.Equal(newName, LinksService.Get(new GetLinkRequest(link.Id)).Title);
            }
        }

        public class ThePostMethod : LinksServiceFacts, IDisposable
        {
            protected int InsertedId { get; set; }
            [Fact]
            [Trait("Verb", "POST")]
            [Trait("ServiceTest", "Link")]
            public void InsertsALink()
            {
                var newLink = new Link { Title = "A new Link", PageId = Database.SeedPages[1].Id };

                InsertedId = (int)LinksService.Post(new InsertLinkRequest(newLink));

                newLink.Id = InsertedId;


                var link = LinksService.Get(new GetLinkRequest(InsertedId));

                Assert.Equal(InsertedId, link.Id);
                Assert.Equal("A new Link", link.Title);
            }

            public void Dispose()
            {
                LinksService.Delete(new DeleteLinkRequest(InsertedId));
            }
        }

        public class TheDeleteMethod : LinksServiceFacts
        {
            [Fact]
            [Trait("Verb", "DELETE")]
            [Trait("ServiceTest", "Link")]
            public void DeletesALink()
            {
                var testlinkFordeletion = (int)LinksService.Post(new InsertLinkRequest(new Link { Title = "DeleteMe", PageId = Database.SeedPages[0].Id }));
                LinksService.Delete(new DeleteLinkRequest(testlinkFordeletion));

                var link = LinksService.Get(new GetLinkRequest(testlinkFordeletion));

                Assert.Null(link);
            }
        }
 
    }