using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{

    [Route("/adGroup/")]
    [Route("/adGroup/{Ids}")]
    [Route("/adGroup/client/{ClientId}")]
    [Route("/adGroup/page/{PageId}")]
    [Route("/adGroup/client/{ClientId}/page/{PageId}")]
    public class AdGroupsDTO : IGetRequestDTO, IReturn<List<AdGroup>>
    {
        public AdGroupsDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int ClientId { get; set; }
        public int PageId { get; set; }
        public int[] Ids { get; set; }
    }
}