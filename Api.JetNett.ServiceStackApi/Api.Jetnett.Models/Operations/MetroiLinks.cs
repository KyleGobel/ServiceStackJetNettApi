using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.JetNett.Models.Operations
{
    /// <summary>
    /// Used for modifying or getting a single MetroiLink
    /// </summary>
    [Api("GET all Metro iLinks or GET or DELETE a single Metro iLink by Id. Use POST to create a new Metro iLink and PUT to update it.")]
    [Route("/metroilinks/{Id}", "GET")]
    [Route("/metroilinks", "GET, POST, PUT, PATCH, DELETE")]
    public class MetroiLinkRequest : IReturn<MetroiLinkResponse>
    {
        public MetroiLinkRequest()
        {
            MetroiLink = new MetroiLinks();
        }
        public int Id { get; set; }
        public MetroiLinks MetroiLink { get; set; }
    }

    /// <summary>
    /// Used for getting all metroiLinks
    /// </summary>
    //public class MetroiLinksRequest : IReturn<MetroiLinksResponse>
    //{ }

    /// <summary>
    /// Response for single metroilink operation
    /// </summary>
    public class MetroiLinkResponse : IHasResponseStatus
    {
        public MetroiLinkResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.MetroiLink = new MetroiLinks();
            this.MetroiLinks = new List<MetroiLinks>();
        }

        public MetroiLinks MetroiLink { get; set; }

        public List<MetroiLinks> MetroiLinks { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    /// <summary>
    /// Response for multiple metroilinks operations
    /// </summary>
    public class MetroiLinksResponse : IHasResponseStatus
    {
        public MetroiLinksResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.MetroiLinks = new List<MetroiLinks>();
        }
        public List<MetroiLinks> MetroiLinks { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
