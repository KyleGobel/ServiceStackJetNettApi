    using System;
    using System.Linq;
    using Api.JetNett.Models.Mixins;
    using Api.JetNett.Models.Operations;
    using Api.JetNett.Models.Types;
    using Api.JetNett.ServiceStackApi;
    using Api.JetNett.ServiceStackApi.Facts.Setup;
    using Xunit;

public class MetroiLinksServiceFacts
    {
       
    protected Db Database { get; set; }
    protected MetroiLinksService MetroiLinksService { get; set; }

    public MetroiLinksServiceFacts()
    {
        Database = new Db();
        Database.SetupDatabase();
        MetroiLinksService = new MetroiLinksService(Database.ConnectionFactory);
    }
    public class TheGetMethod 
    {
        public class ListClientsOverload : MetroiLinksServiceFacts
        {
            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "MetroiLink")]
            public void ReturnsAllMetroiLinks_WhenCalledWithEmptyListRequest()
            {
                var results = MetroiLinksService.Get(new ListMetroiLinksRequest());
                Assert.Equal(Database.SeedMetroiLinks, results);
            }

            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "MetroiLink")]
            public void ReturnsMetroiLinks_WhenCalledWithListOfIds()
            {
                var metroilink = Database.SeedMetroiLinks[0];
                var results = MetroiLinksService.Get(new ListMetroiLinksRequest {Ids = metroilink.Id.ToEnumerable().ToArray()});

                Assert.Equal(1, results.Count);
                Assert.Equal(metroilink, results[0]);
            }
        }

        public class GetClientsRequestOverload : MetroiLinksServiceFacts
        {
            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "MetroiLink")]
            public void ReturnsMetroiLinkWithIdGivenToRequest()
            {
                var result = MetroiLinksService.Get(new GetMetroiLinksRequest(Database.SeedMetroiLinks[0].Id));

                Assert.Equal(Database.SeedMetroiLinks[0], result);
            }
        }
    }

    public class ThePutMethod : MetroiLinksServiceFacts
    {
        [Fact]
        [Trait("Verb", "PUT")]
        [Trait("ServiceTest", "MetroiLink")]
        public void UpdatesAClient()
        {
            const string newName = "An updated name";
            var metroiLink = Database.SeedMetroiLinks[0];
            MetroiLinksService.Put(new UpdateMetroiLinksRequest(new MetroiLinks { Id = metroiLink.Id,ClientId = metroiLink.ClientId, ClientLogoAltText= newName}));


            Assert.Equal(newName, MetroiLinksService.Get(new GetMetroiLinksRequest(metroiLink.Id)).ClientLogoAltText);
        }
    }

    public class ThePostMethod : MetroiLinksServiceFacts, IDisposable
    {
        protected int InsertedId { get; set; }
        [Fact]
        [Trait("Verb", "POST")]
        [Trait("ServiceTest", "MetroiLink")]
        public void InsertsAClient()
        {
            var metroiLink = new MetroiLinks {ClientId = Database.SeedClients[0].Id, FontSizePx = 26};

            InsertedId = (int)MetroiLinksService.Post(new InsertMetroiLinksRequest(metroiLink));

            metroiLink.Id = InsertedId;


            var insertedMeg = MetroiLinksService.Get(new GetMetroiLinksRequest(InsertedId));

            Assert.Equal(InsertedId, insertedMeg.Id);
            Assert.Equal(metroiLink.FontSizePx, insertedMeg.FontSizePx);
        }

        public void Dispose()
        {
            MetroiLinksService.Delete(new DeleteMetroiLinksRequest(InsertedId));
        }
    }

    public class TheDeleteMethod : MetroiLinksServiceFacts
    {
        [Fact]
        [Trait("Verb", "DELETE")]
        [Trait("ServiceTest", "MetroiLink")]
        public void DeletesAClient()
        {
            var testClientForDeletetionId = (int) MetroiLinksService.Post(new InsertMetroiLinksRequest(new MetroiLinks {ClientId=Database.SeedClients[0].Id}));
            MetroiLinksService.Delete(new DeleteMetroiLinksRequest(testClientForDeletetionId));

            var metroiLink = MetroiLinksService.Get(new GetMetroiLinksRequest(testClientForDeletetionId));

            Assert.Null(metroiLink);
        }
    }   
    }