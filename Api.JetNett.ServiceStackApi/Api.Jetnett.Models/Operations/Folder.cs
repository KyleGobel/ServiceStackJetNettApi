using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Api.JetNett.Models.Operations
{
    [Api("GET all Clients or GET or DELETE a single Client by Id. Use POST to create a new Client and PUT to update it.")]
    [Route("/folder/{Id}", "GET")]
    [Route("/folder", "GET, POST, PUT, PATCH, DELETE")]
    [Route("/folder/children/{ParentId}", "GET")]
    public class FolderRequestDTO : IRequestDTO<Folder>, IReturn<Folder>
    {
        public FolderRequestDTO()
        {
            Entity = new Folder();
        }
        public int Id { get; set; }

        public int ParentId { get; set; }
        public Folder Entity { get; set; }
    }

    public class FolderResponseDTO : IResponseDTO<Folder>, IHasResponseStatus
    {
        public FolderResponseDTO()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Entity = new Folder();
            this.Entities = new List<Folder>();
        }

        public ResponseStatus ResponseStatus { get; set; }

        public Folder Entity { get; set; }
        public List<Folder> Entities { get; set; }
    }
}
