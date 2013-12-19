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
    
    public class LinkService : Service
    {
        protected OrmLiteRepository<Link> Repository { get; set; }

        public LinkService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<Link>(dbConnectionFactory.Open());
        }


        public Link Get(GetLinkRequest request)
        {
            return Repository.GetById(request.Id);
        }

        public List<Link> Get(ListLinksRequest request)
        {
            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();

            if (request.PageId != default(int))
                return Repository.Where(x => x.PageId == request.PageId).ToList();
            return Repository.GetAll().ToList();
        }

        public void Put(UpdateLinkRequest request)
        {
            Repository.Update(request.Entity);
        }

        public void Delete(DeleteLinkRequest request)
        {
            Repository.Delete(request.Id.ToEnumerable());
        }

        public int Post(InsertLinkRequest request)
        {
            return (int)Repository.Insert(request.Entity);
        }
    }
}