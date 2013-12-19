using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/folders", "GET")]
    [Route("/folders/{ParentId}/children")]
    [Route("/folders/{Ids}")]
    public class ListFoldersRequest : IHaveManyIds, IReturn<List<Folder>>
    {
        public int[] Ids { get; set; }
        public int ParentId { get; set; }
    }

    [Route("/folders/{Id}", "GET")]
    public class GetFolderRequest : IHaveId, IReturn<Folder>
    {
        public int Id { get; set; }

        public GetFolderRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/folders/", "POST")]
    [Authenticate(ApplyTo.Post)]
    public class InsertFolderRequest : IHaveEntity<Folder>, IReturn<int>
    {
        public Folder Entity { get; set; }

        public InsertFolderRequest(Folder entity)
        {
            Entity = entity;
        }
    }

    [Route("/folders/", "DELETE")]
    [Authenticate(ApplyTo.Delete)]
    public class DeleteFolderRequest : IHaveId
    {
        public int Id { get; set; }

        public DeleteFolderRequest(int id)
        {
            this.Id = id;
        }
    }

    [Route("/folders/{Id}", "PUT")]
    [Authenticate(ApplyTo.Put)]
    public class UpdateFolderRequest : IHaveEntity<Folder>
    {
        public Folder Entity { get; set; }

        public UpdateFolderRequest(Folder entity)
        {
            this.Entity = entity;
        }
    }
}