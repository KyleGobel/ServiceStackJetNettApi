using System.Collections.Generic;
using Api.Jetnett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.Jetnett.Models.Operations
{
    [Route("/metroilinks/{ClientId}", "GET")]
    [Route("/metroilinks/", "GET")]
    public class MetroiLinksQuery : IReturn<Types.MetroiLinks>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
    }
 
    public class MetroiLinksResponse : IHasResponseStatus
    {
        public MetroiLinksResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.MetroiLink = new MetroiLinks();
            this.MetroiLinks = new List<MetroiLinks>();
        }

        public MetroiLinks MetroiLink { get; set; }

        public List<MetroiLinks> MetroiLinks { get; set; }

        public ResponseStatus ResponseStatus { get; set; }

    }
}
