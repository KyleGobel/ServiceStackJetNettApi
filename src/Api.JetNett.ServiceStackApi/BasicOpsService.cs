using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class BasicOpsService<TModel> : Service where TModel: class, new()
    {
        protected OrmLiteRepository<TModel> Repository { get; set; }

        public BasicOpsService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<TModel>(dbConnectionFactory.Open());
        }

        public virtual TModel Get(IHaveId request)
        {
            return Repository.GetById(request.Id);
        }

        public virtual List<TModel> Get(IHaveManyIds request)
        {
            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();
            return Repository.GetAll().ToList();
        }

        public virtual void Put(IHaveEntity<TModel> request)
        {
            Repository.Update(request.Entity);
        }

        public virtual void Delete(IHaveId request)
        {
            Repository.Delete(request.Id.ToEnumerable());
        }

        public virtual void Delete(IHaveManyIds request)
        {
            Repository.Delete(request.Ids);
        }

        public virtual long Post(IHaveEntity<TModel> request)
        {
            return Repository.Insert(request.Entity);
        }
    }
}