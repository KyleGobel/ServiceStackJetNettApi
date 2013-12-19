using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/pages", "GET")]
    [Route("/folders/{FolderId}/pages", "GET")]
    [Route("/pages/{Ids}", "GET")]
    public class ListPagesRequest : IHaveManyIds, IReturn<List<Page>>
    {
        public int[] Ids { get; set; }
        public int? FolderId { get; set; }
    }

    [Route("/pages/{Id}", "GET")]
    public class GetPageRequest : IHaveId, IReturn<Page>
    {
        public int Id { get; set; }

        public GetPageRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/pages/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertPageRequest : IHaveEntity<Page>, IReturn<int>
    {
        public Page Entity { get; set; }

        public InsertPageRequest(Page entity)
        {
            this.Entity = entity;
        }
    }

    [Route("/pages/", "DELETE")]
    [Authenticate(ApplyTo.Delete)]
    public class DeletePageRequest : IHaveId
    {
        public int Id { get; set; }

        public DeletePageRequest(int id)
        {
            this.Id = id;
        }

        public DeletePageRequest()
        { }
    }

    [Route("/pages/{Id}", "PUT")]
    [Authenticate(ApplyTo.Put)]
    public class UpdatePageRequest : IHaveEntity<Page>, IHaveId
    {
        public int Id { get; set; }
        public Page Entity { get; set; }
        public UpdatePageRequest(int id, Page entity)
        {
            this.Id = id;
            this.Entity = entity;
        }

        public UpdatePageRequest()
        { }
    }

   

    [Route("/pages/paths/{Ids}", "GET")]
    public class PagesWithPathsAsTitles : IReturn<List<Page>> 
    {
        public int[] Ids { get; set; }
        public PagesWithPathsAsTitles(params int[] ids)
        {
            this.Ids = ids;
        }
    }
}