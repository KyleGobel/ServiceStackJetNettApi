using System.Collections.Generic;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class FolderService : JetNettService<FoldersDTO, Folder>
    {
        public FolderService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override IEnumerable<Folder> Get(FoldersDTO request)
        {
            return default(int) != request.ParentId 
                ? Db.Where<Folder>("ParentFolderId", request.ParentId) 
                : base.Get(request);
        }
    }
}