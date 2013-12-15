using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/pages")]
    [Route("/folders/{FolderId}/pages")]
    [Route("/pages/{Ids}")]
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