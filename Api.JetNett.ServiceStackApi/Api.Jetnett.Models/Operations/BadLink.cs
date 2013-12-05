using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{

    [Api("Standard BadLinks Entity Service.")]
    [Route("/badlink/{Id}", "GET")]
    [Route("/badlink", "GET, POST, PUT, PATCH, DELETE")]
    public class BadLinkRequestDTO : IRequestDTO<BadLink>
    {
        public int Id { get; set; }
        public BadLink Entity { get; set; }
    }

    public class BadLinkResponseDTO : IResponseDTO<BadLink>
    {
        public BadLink Entity { get; set; }
        public List<BadLink> Entities { get; set; }
    }
}