﻿using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack.ServiceHost;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all Zipcodes for a page or GET or DELETE a single Page Zipcode by Id. Use POST to create a new Zipcode for a page and PUT to update it.")]
    [Route("/zipcode/{Id}", "GET")]
    [Route("/zipcode", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/zipcode/page/{PageId}", "GET")]
    public class CommunityZipcodesRequestDTO : IRequestDTO<CommunityZipcodes>, IReturn<CommunityZipcodesResponseDTO>
    {
        public int Id { get; set; }
        public int PageId {get; set;}
        public CommunityZipcodes Entity { get; set; }
    }

    public class CommunityZipcodesResponseDTO : IResponseDTO<CommunityZipcodes>
    {
        public CommunityZipcodes Entity { get; set; }
        public List<CommunityZipcodes> Entities { get; set; }
    }
}
