using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all Zipcodes for a page or GET or DELETE a single Page Zipcode by Id. Use POST to create a new Zipcode for a page and PUT to update it.")]
    [Route("/zipcode/{Ids}", "GET")]
    [Route("/zipcode", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/zipcode/page/{PageId}", "GET")]
    public class CommunityZipcodesRequestDTO : IRequestDTO<CommunityZipcodes>, IReturn<CommunityZipcodesResponseDTO>
    {
        public IEnumerable<int> Ids { get; set; }
        public int PageId {get; set;}
        public CommunityZipcodes Entity { get; set; }
    }

    public class CommunityZipcodesResponseDTO : IResponseDTO<CommunityZipcodes>
    {
        public CommunityZipcodes Entity { get; set; }
        public IEnumerable<CommunityZipcodes> Entities { get; set; }
    }
}
