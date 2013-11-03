﻿using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.JetNett.Models.Operations
{
  
        [Api("GET all Pages or GET or DELETE a single Page by Id. Use POST to create a new Page and PUT to update it.")]
        [Route("/page/{Id}", "GET")]
        [Route("/page", "GET, POST, PUT, PATCH, DELETE")]
        public class PagesRequestDTO : IRequestDTO<Page>, IReturn<PagesResponseDTO>
        {
            public PagesRequestDTO()
            {
                Entity = new Page();
            }
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public Page Entity { get; set; }
        }

        public class PagesResponseDTO : IResponseDTO<Page>, IHasResponseStatus
        {
            public PagesResponseDTO()
            {
                this.ResponseStatus = new ResponseStatus();
                this.Entity = new Page();
                this.Entities = new List<Page>();
            }

            public ResponseStatus ResponseStatus { get; set; }

            public Page Entity { get; set; }
            public List<Page> Entities { get; set; }
        } 
}