using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/links/{Ids}")]
    [Route("/links/page/{PageId}")]
    [Route("/links")]
    public class LinksDTO : IGetRequestDTO, IReturn<List<Link>>
    {
        public int[] Ids { get; set; }
        public int PageId { get; set; }
    }
}
