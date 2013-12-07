using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    /// <summary>
    /// Used for modifying or getting a single MetroiLink
    /// </summary>
    [Api("GET all Metro iLinks or GET or DELETE a single Metro iLink by Id. Use POST to create a new Metro iLink and PUT to update it.")]
    [Route("/metroilinks/{Ids}", "GET")]
    [Route("/metroilinks", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/metroilinks/client/{ClientId}", "GET")]
    public class MetroiLinkRequestDTO : IReturn<MetroiLinksResponseDTO>, IRequestDTO<MetroiLinks>
    {
        public MetroiLinkRequestDTO()
        {
            Entity = new MetroiLinks();
        }
        public IEnumerable<int> Ids { get; set; }
        public int ClientId { get; set; }
        public MetroiLinks Entity { get; set; }
    }

   
    public class MetroiLinksResponseDTO : IHasResponseStatus, IResponseDTO<MetroiLinks>
    {
        public MetroiLinksResponseDTO()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Entity = new MetroiLinks();
            this.Entities = new List<MetroiLinks>();
        }

        public ResponseStatus ResponseStatus { get; set; }
        public MetroiLinks Entity { get; set; }
        public IEnumerable<MetroiLinks> Entities { get; set; }
    }
}
