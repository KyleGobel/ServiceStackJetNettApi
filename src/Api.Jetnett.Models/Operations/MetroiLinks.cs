using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    /// <summary>
    /// Used for modifying or getting a single MetroiLink
    /// </summary>
    [Route("/metroilinks/{Ids}")]
    [Route("/metroilinks")]
    [Route("/metroilinks/client/{ClientId}")]
    public class MetroiLinksDTO : IGetRequestDTO, IReturn<List<MetroiLinks>>
    {
        public MetroiLinksDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int[] Ids { get; set; }
        public int ClientId { get; set; }
    }
}
