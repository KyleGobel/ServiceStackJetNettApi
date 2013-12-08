using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class PagesService : JetNettService<PagesDTO,Page>
    { 
        public PagesService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override IEnumerable<Page> Get(PagesDTO request)
        {
            if (request.FolderId != default(int))
            {
                return Repository.Where(x => x.FolderId == request.FolderId);
            }
            if (request.PathPageId != default(int))
            {
                var page = Repository.GetByIds(request.PathPageId.ToEnumerable()).SingleOrDefault();

                if (page == null)
                    return null;

                var folderPath = GetFolderPath(page.FolderId);

                page.Title = folderPath + page.Title;
                return page.ToEnumerable();
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