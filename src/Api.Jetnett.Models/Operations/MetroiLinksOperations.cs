using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/metroilinks", "GET")]
    [Route("/metroilinks/{Ids}")]
    public class ListMetroiLinksRequest : IHaveManyIds, IReturn<List<MetroiLinks>>
    {
        public int[] Ids { get; set; }
    }

    [Route("/metroilinks/{Id}", "GET")]
    public class GetMetroiLinksRequest : IHaveId, IReturn<MetroiLinks>
    {
        public int Id { get; set; }

        public GetMetroiLinksRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/clients/{ClientId}/metroilinks")]
    public class GetMetroiLinksFromClientIdRequest : IReturn<MetroiLinks>
    {
        public int ClientId { get; set; }
        public GetMetroiLinksFromClientIdRequest(int clientId)
        {
            this.ClientId = clientId;
        }
    }

    [Route("/metroilinks/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertMetroiLinksRequest : IHaveEntity<MetroiLinks>, IReturn<int>
    {
        public MetroiLinks Entity { get; set; }

        public InsertMetroiLinksRequest(MetroiLinks entity)
        {
            Entity = entity;
        }
    }

    [Route("/metroilinks/", "DELETE")]
    [Authenticate(ApplyTo.Delete)]
    public class DeleteMetroiLinksRequest : IHaveId
    {
        public int Id { get; set; }

        public DeleteMetroiLinksRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/metroilinks/", "PUT")]
    [Authenticate(ApplyTo.Put)]
    public class UpdateMetroiLinksRequest : IHaveEntity<MetroiLinks>
    {
        public MetroiLinks Entity { get; set; }

        public UpdateMetroiLinksRequest(MetroiLinks entity)
        {
            this.Entity = entity;
        }
    }
}
