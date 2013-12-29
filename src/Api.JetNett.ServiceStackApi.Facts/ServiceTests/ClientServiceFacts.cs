using System;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using Xunit;

public class ClientServiceFacts
{
    protected Db Database { get; set; }
    protected ClientsService ClientService { get; set; }

    public ClientServiceFacts()
    {
        Database = new Db();
        Database.SetupDatabase();
        ClientService = new ClientsService(Database.ConnectionFactory);
    }
    public class TheGetMethod 
    {
        public class ListClientsOverload : ClientServiceFacts
        {
            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "Client")]
            public void ReturnsAllClients_WhenCalledWithEmptyListRequest()
            {
                var results = ClientService.Get(new ListClientsRequest());
                Assert.Equal(Database.SeedClients, results);
            }

            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "Client")]
            public void ReturnsClients_WhenCalledWithListOfIds()
            {
                var folder = Database.SeedClients[0];
                var results = ClientService.Get(new ListClientsRequest() {Ids = folder.Id.ToEnumerable().ToArray()});

                Assert.Equal(1, results.Count);
                Assert.Equal(folder, results[0]);
            }
        }

        public class GetClientsRequestOverload : ClientServiceFacts
        {
            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "Client")]
            public void ReturnsClientWithIdGivenToRequest()
            {
                var result = ClientService.Get(new GetClientRequest(Database.SeedClients[0].Id));

                Assert.Equal(Database.SeedClients[0], result);
            }

            [Fact]
            [Trait("Verb", "GET")]
            [Trait("ServiceTest", "Client")]
            public void ReturnsClientWithUsernameAndPassword()
            {
                var result = ClientService.Get(new GetClientRequest(Database.SeedClients[0].UserId,Database.SeedClients[0].Password));

                Assert.Equal(result, Database.SeedClients[0]);
            }
        }
    }

    public class ThePutMethod : ClientServiceFacts
    {
        [Fact]
        [Trait("Verb", "PUT")]
        [Trait("ServiceTest", "Client")]
        public void UpdatesAClient()
        {
            const string newName = "An updated name";
            var client = Database.SeedClients[0];
            ClientService.Put(new UpdateClientRequest(new Client() { Id = client.Id, Name=newName}));


            Assert.Equal(newName, ClientService.Get(new GetClientRequest(client.Id)).Name);
        }
    }

    public class ThePostMethod : ClientServiceFacts, IDisposable
    {
        protected int InsertedId { get; set; }
        [Fact]
        [Trait("Verb", "POST")]
        [Trait("ServiceTest", "Client")]
        public void InsertsAClient()
        {
            var newClient = new Client {Name = "A new Client", UserId="random", Password = "rnadom"};

            InsertedId = (int)ClientService.Post(new InsertClientRequest(newClient));

            newClient.Id = InsertedId;


            var client = ClientService.Get(new GetClientRequest(InsertedId));

            Assert.Equal(InsertedId, client.Id);
            Assert.Equal("A new Client", client.Name);
        }

        public void Dispose()
        {
            ClientService.Delete(new DeleteClientRequest(InsertedId));
        }
    }

    public class TheDeleteMethod : ClientServiceFacts
    {
        [Fact]
        [Trait("Verb", "DELETE")]
        [Trait("ServiceTest", "Client")]
        public void DeletesAClient()
        {
            var testClientForDeletetionId = (int) ClientService.Post(new InsertClientRequest(new Client() {Name="DeleteMe"}));
            ClientService.Delete(new DeleteClientRequest(testClientForDeletetionId));

            var client = ClientService.Get(new GetClientRequest(testClientForDeletetionId));

            Assert.Null(client);
        }
    } 
}