using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/pages", "GET")]
    [Route("/folders/{FolderId}/pages", "GET")]
    [Route("/pages/{Ids}", "GET")]
    public class ListPagesRequest : IReturn<List<Page>>
    {
        public int[] Ids { get; set; }
        public int? FolderId { get; set; }
    }

    [Route("/pages/{Id}", "GET")]
    public class PageRequest : IReturn<Page>
    {
        public int Id { get; set; }

        public PageRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/pages/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertPageRequest : IReturn<int>
    {
        public Page PageToInsert { get; set; }

        public InsertPageRequest(Page pageToInsert)
        {
            this.PageToInsert = pageToInsert;
        }
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