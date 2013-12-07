using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{

    [Api("Standard BadLinks Entity Service.")]
    [Route("/badlink/{Ids}", "GET")]
    [Route("/badlink", "GET, POST, PUT, PATCH, DELETE")]
    public class BadLinkRequestDTO : IRequestDTO<BadLink>, IReturn<BadLinkResponseDTO>
    {
        public IEnumerable<int> Ids { get; set; }
        public BadLink Entity { get; set; }
    }

    public class BadLinkResponseDTO : IResponseDTO<BadLink>
    {
        public IEnumerable<BadLink> Entities { get; set; }
    }
}