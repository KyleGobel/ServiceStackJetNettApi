using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class PagesService : JetNettService<PagesRequestDTO,PagesResponseDTO,Page>
    { 
        public PagesService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override PagesResponseDTO Get(PagesRequestDTO request)
        {
            if (request.FolderId != default(int))
            {
                return new PagesResponseDTO
                {
                    Entities = Repository.Where(x => x.FolderId == request.FolderId)
                };
            }
            if (request.PathPageId != default(int))
            {
                var page = Repository.GetById(request.PathPageId);

                var folderPath = GetFolderPath(page.FolderId);

                page.Title = folderPath + page.Title;
                return new PagesResponseDTO
                {
                    Entity = page
                };
            }
            return base.Get(request);
        }

        private string GetFolderPath(int? folderId, string path = "")
        {
            if (folderId == null || folderId == 0)
                return path;

            var folder = Db.SingleWhere<Folder>("FolderID", folderId);
            if (folder != null)
            {
                path = path.Insert(0, folder.Name + ">");
                return GetFolderPath(folder.ParentFolderId, path);
            }
            return "";
        }
    }
}