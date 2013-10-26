using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.JetNett.Models.Operations
{
    [Route("/metroilinks/{ClientId}", "GET")]
    [Route("/metroilinks/", "GET")]
    public class MetroiLinksQuery : IReturn<MetroiLinksResponse>
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
