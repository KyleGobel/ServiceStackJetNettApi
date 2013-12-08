using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/zipcode/{Ids}")]
    [Route("/zipcode")]
    [Route("/zipcode/page/{PageId}")]
    public class CommunityZipcodesDTO : IGetRequestDTO, IReturn<List<CommunityZipcodes>>
    {
        public CommunityZipcodesDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int[] Ids { get; set; }
        public int PageId {get; set;}
    }
}
