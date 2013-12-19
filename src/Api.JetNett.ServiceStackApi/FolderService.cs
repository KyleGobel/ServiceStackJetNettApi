using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{

    public class FolderService : Service
    {
        protected OrmLiteRepository<Folder> Repository { get; set; }

        public FolderService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<Folder>(dbConnectionFactory.Open());
        }


        public Folder Get(GetFolderRequest request)
        {
            return Repository.GetById(request.Id);
        }

        public List<Folder> Get(ListFoldersRequest request)
        {
            if (request.ParentId != default (int))
                return Repository.Where(x => x.ParentFolderId == request.ParentId).ToList();

            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();
            return Repository.GetAll().ToList();
        }

        public void Put(UpdateFolderRequest request)
        {
            Repository.Update(request.Entity);
        }

        public void Delete(DeleteFolderRequest request)
        {
            Repository.Delete(request.Id.ToEnumerable());
        }

        public long Post(InsertFolderRequest request)
        {
            return Repository.Insert(request.Entity);
        }
    }
}