using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/clients", "GET")]
    [Route("/clients/{Ids}")]
    public class ListClientsRequest : IHaveManyIds, IReturn<List<Client>>
    {
        public int[] Ids { get; set; }
    }

    [Route("/clients/{Id}", "GET")]
    public class GetClientRequest : IHaveId, IReturn<Client>
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public GetClientRequest(int id)
        {
            this.Id = id;
        }

        public GetClientRequest(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }

    [Route("/clients/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertClientRequest : IHaveEntity<Client>, IReturn<int>
    {
        public Client Entity { get; set; }

        public InsertClientRequest(Client entity)
        {
            Entity = entity;
        }
    }

    [Route("/clients/", "DELETE")]
    [Authenticate(ApplyTo.Delete)]
    public class DeleteClientRequest : IHaveId
    {
        public int Id { get; set; }

        public DeleteClientRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/clients/{Id}", "PUT")]
    [Authenticate(ApplyTo.Put)]
    public class UpdateClientRequest : IHaveEntity<Client>
    {
        public Client Entity { get; set; }

        public UpdateClientRequest(Client entity)
        {
            this.Entity = entity;
        }
    }
}