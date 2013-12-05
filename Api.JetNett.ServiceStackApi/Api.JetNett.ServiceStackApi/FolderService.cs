using System.Security.Cryptography.X509Certificates;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class FolderService : JetNettService<FolderRequestDTO, FolderResponseDTO, Folder>
    {
        public FolderService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override FolderResponseDTO Get(FolderRequestDTO request)
        {
            
            if (default(int) != request.ParentId)
            {
                return new FolderResponseDTO
                {
                    Entities = Db.Where<Folder>("ParentFolderId", request.ParentId)
                };
            }
            return base.Get(request);
        }
    }
}