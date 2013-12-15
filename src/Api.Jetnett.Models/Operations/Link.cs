using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/links")]
    [Route("/links/page/{pageId}")]
    public class LinksDTO : IGetRequestDTO, IReturn<List<Link>>
    {
        public LinksDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int[] Ids { get; set; }
        public int PageId { get; set; }
    }
}
