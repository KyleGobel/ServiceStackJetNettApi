using Api.Jetnett.Models.Models;
using Api.Jetnett.Models.Types;
using ServiceStack.ServiceHost;

namespace Api.JetNett.ServiceStackApi
{
    [Route("/metroilinks/{ClientId}", "GET")]
    [Route("/metroilinks/", "GET")]
    public class MetroiLinksQuery : IReturn<MetroiLinks>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
    }
}