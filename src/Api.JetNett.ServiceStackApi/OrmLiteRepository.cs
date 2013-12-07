using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class OrmLiteRepository<T> : IRepository<T> where T : class, new()
    {
        protected IDbConnection Db { get; set; }
        public OrmLiteRepository(IDbConnection dbConnection)
        {
            Db = dbConnection; 
        }
        
        public virtual IEnumerable<T> GetAll()
        {
            return Db.Select<T>();
        }

        public virtual IEnumerable<T> GetByIds(IEnumerable<int> ids)
        {
            return Db.SelectByIds<T>(ids);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> whereExpression)
        {
            return Db.Where<T>(whereExpression);
        }

        public virtual long Insert(T entity)
        {
            return Db.Insert(entity);
        }

        public virtual void Update(T entity)
        {
            Db.Update(entity); 
        }

        public virtual void Delete(IEnumerable<int> ids)
        {
            Db.DeleteByIds<T>(ids);
        }
    }
}