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

    public class MetroiLinksService : Service
    {
        protected OrmLiteRepository<MetroiLinks> Repository { get; set; }

        public MetroiLinksService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<MetroiLinks>(dbConnectionFactory.Open());
        }


        public MetroiLinks Get(GetMetroiLinksRequest request)
        {
            return Repository.GetById(request.Id);
        }

        public MetroiLinks Get(GetMetroiLinksFromClientIdRequest request)
        {
            return Repository.Where(x => x.ClientId == request.ClientId).Single();
        }
        public List<MetroiLinks> Get(ListMetroiLinksRequest request)
        {
            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();
            return Repository.GetAll().ToList();
        }

        public void Put(UpdateMetroiLinksRequest request)
        {
            Repository.Update(request.Entity);
        }

        public void Delete(DeleteMetroiLinksRequest request)
        {
            Repository.Delete(request.Id.ToEnumerable());
        }

        public int Post(InsertMetroiLinksRequest request)
        {
            return (int)Repository.Insert(request.Entity);
        }
    }
}