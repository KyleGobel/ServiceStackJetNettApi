using System;
using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{

    public class PagesService : Service
    {
        protected OrmLiteRepository<Page> Repository { get; set; }

        public PagesService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<Page>(dbConnectionFactory.Open());
        }

        public Page Get(PageRequest request)
        {
            return Repository.GetByIds(request.Id.ToEnumerable()).SingleOrDefault();
        }

        public List<Page> Get(ListPagesRequest request)
        {
            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();
            if (request.FolderId != default(int?))
                return Repository.Where(x => x.FolderId == request.FolderId).ToList();

            return Repository.GetAll().ToList();
        }

        public int Post(InsertPageRequest request)
        {
            return Convert.ToInt32(Repository.Insert(request.PageToInsert));
        }
    }

    public class PagePathInfoService : Service
    {
        protected OrmLiteRepository<Page> Repository { get; set; }
        public PagePathInfoService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<Page>(dbConnectionFactory.Open());
        }

        public List<Page> Get(PagesWithPathsAsTitles request)
        {
            var pages = Repository.GetByIds(request.Ids);

            if (pages == null)
                return null;

            var newPages = pages.ToList().Select(x =>
            {
                var folderPath = GetFolderPath(x.FolderId);
                x.Title = folderPath + x.Title;
                return x;
            });

            return newPages.ToList();
        }

        private string GetFolderPath(int? folderId, string path = "")
        {
            if (folderId == null || folderId == 0)
                return path;

            var folder = Db.SingleWhere<Folder>("ID", folderId);
            if (folder != null)
            {
                path = path.Insert(0, folder.Name + " > ");
                return GetFolderPath(folder.ParentFolderId, path);
            }
            return "";
        }
    }
}