using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace Api.JetNett.ServiceStackApi
{
    public class OrmLiteRepository<T> : Service, IRepository<T> where T : class
    {
        public virtual T GetById(int id)
        {
            return Db.GetById<T>(id);
        }

        public virtual List<T> GetAll()
        {
            return Db.Select<T>();
        }

        public virtual T GetWhere(Expression<Func<T, bool>> whereExpression)
        {
            return Db.Where(whereExpression).SingleOrDefault();
        }

    
    }
}