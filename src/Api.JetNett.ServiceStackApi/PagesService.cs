using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
 

    public class PagesService : BasicOpsService<Page>
    {
        public PagesService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public Page Get(GetPageRequest request)
        {
            return base.Get(request);
        }

        public List<Page> Get(ListPagesRequest request)
        {
            if (request == null)
            {
                return base.Get(request);
            }

            if (request.FolderId != default(int?))
                return Repository.Where(x => x.FolderId == request.FolderId).ToList();

            return base.Get(request);
        }

        public void Put(UpdatePageRequest request)
        {
            base.Put(request);
        }

        public void Delete(DeletePageRequest request)
        {
            base.Delete(request); 
        }

        public long Post(InsertPageRequest request)
        {
            return base.Post(request);
        }
    }

    public class PagePathInfoService : Service
    {
        protected OrmLiteRepository<Page> Repository { get; set; }
        protected OrmLiteRepository<Folder> FolderRepo { get; set; } 
        public PagePathInfoService(IDbConnectionFactory dbConnectionFactory)
        {
            var db = dbConnectionFactory.Open();
            Repository = new OrmLiteRepository<Page>(db);
            FolderRepo = new OrmLiteRepository<Folder>(db);
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

            var folder = FolderRepo.Where(x => x.Id == folderId).SingleOrDefault();
            if (folder != null)
            {
                path = path.Insert(0, folder.Name + " > ");
                return GetFolderPath(folder.ParentFolderId, path);
            }
            return "";
        }
    }
}