using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/links", "GET")]
    [Route("/pages/{PageId}/links")]
    [Route("/links/{Ids}")]
    public class ListLinksRequest : IHaveManyIds, IReturn<List<Link>>
    {
        public int[] Ids { get; set; }
        public int PageId { get; set; }
    }

    [Route("/links/{Id}", "GET")]
    public class GetLinkRequest : IHaveId, IReturn<Link>
    {
        public int Id { get; set; }

        public GetLinkRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/links/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertLinkRequest : IHaveEntity<Link>, IReturn<int>
    {
        public Link Entity { get; set; }

        public InsertLinkRequest(Link entity)
        {
            Entity = entity;
        }
    }

    [Route("/links/", "DELETE")]
    [Authenticate(ApplyTo.Delete)]
    public class DeleteLinkRequest : IHaveId
    {
        public int Id { get; set; }

        public DeleteLinkRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/links/{Id}", "PUT")]
    [Authenticate(ApplyTo.Put)]
    public class UpdateLinkRequest : IHaveEntity<Link>
    {
        public Link Entity { get; set; }

        public UpdateLinkRequest(Link entity)
        {
            this.Entity = entity;
        }
    }
}
