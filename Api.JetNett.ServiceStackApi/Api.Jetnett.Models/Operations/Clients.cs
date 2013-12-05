using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all Clients or GET or DELETE a single Client by Id. Use POST to create a new Client and PUT to update it.")]
    [Route("/client/{Id}", "GET")]
    [Route("/client", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/client/{Username}/{Password}", "GET")]
    public class ClientRequestDTO : IRequestDTO<Client> ,IReturn<Client>
    {
        public ClientRequestDTO()
        {
            Entity = new Client();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Client Entity { get; set; }
    }

    public class ClientResponseDTO : IResponseDTO<Client>, IHasResponseStatus
    {
        public ClientResponseDTO()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Entity = new Client();
            this.Entities = new List<Client>();
        }

        public ResponseStatus ResponseStatus { get; set; }

        public Client Entity { get; set; }
        public List<Client> Entities { get; set; }
    }
}