using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all links or GET or DELETE a single Metro iLink by Id. Use POST to create a new link and PUT to update it.")]
    [Route("/links/{Ids}", "GET")]
    [Route("/links", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/links/page/{PageId}", "GET")]
    public class LinkRequestDTO : IRequestDTO<Link>, IReturn<LinkResponseDTO>
    {
        public IEnumerable<int> Ids { get; set; } 
        public Link Entity { get; set; }
        public int PageId { get; set; }
    }

    public class LinkResponseDTO : IResponseDTO<Link>
    {
        public Link Entity { get; set; }
        public IEnumerable<Link> Entities { get; set; }
    }
}
