using System.Collections.Generic;
using Api.Jetnett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.Jetnett.Models.Operations
{
    [Route("/client", "GET")] //Returns All Clients
    [Route("/client/{Id}", "GET")] //Returns Client
    [Route("/client/{Username}/{Password}", "GET")] //Returns Client
    public class ClientQuery : IReturn<Client>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }

    public class ClientResponse : IHasResponseStatus
    {
        public ClientResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Client = new Client();
            this.Clients = new List<Client>();
        }

        public ResponseStatus ResponseStatus { get; set; }

        public Client Client { get; set; }

        public List<Client> Clients { get; set; }
    }
}