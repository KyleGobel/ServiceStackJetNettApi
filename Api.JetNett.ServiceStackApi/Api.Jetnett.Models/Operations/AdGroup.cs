﻿using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all AdGroups or GET or DELETE a single AdGroup by Id. Use POST to create a new AdGroup and PUT to update it.")]
    [Route("/adGroup/{Ids}", "GET")]
    [Route("/adGroup", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/adGroup/client/{ClientId}", "GET")]
    [Route("/adGroup/page/{PageId}", "GET")]
    [Route("/adGroup/client/{ClientId}/page/{PageId}")]
    public class AdGroupRequestDTO : IRequestDTO<AdGroup>, IReturn<AdGroupResponseDTO>
    {
        public IEnumerable<int> Ids { get; set; }
        public AdGroup Entity { get; set; }

        public int ClientId { get; set; }
        public int PageId { get; set; }
    }

    public class AdGroupResponseDTO : IResponseDTO<AdGroup>
    {
        public IEnumerable<AdGroup> Entities { get; set; }
    }
}