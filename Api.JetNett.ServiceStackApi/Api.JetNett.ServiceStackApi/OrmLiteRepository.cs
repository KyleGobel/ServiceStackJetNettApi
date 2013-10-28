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
        public virtual T GetById(int id)
        {
            return Db.GetByIdOrDefault<T>(id);
        }

        public virtual List<T> GetAll()
        {
            return Db.Select<T>();
        }

        public virtual List<T> Where(Expression<Func<T, bool>> whereExpression)
        {
            return Db.Where(whereExpression);
        }

        public virtual long Insert(T entity)
        {
            Db.Insert(entity);
            return Db.GetLastInsertId();
        }

        public virtual void Update(T entity)
        {
            Db.Update(entity); 
        }

        public virtual void Delete(int id)
        {
            Db.DeleteById<T>(id);
        }
    }
}