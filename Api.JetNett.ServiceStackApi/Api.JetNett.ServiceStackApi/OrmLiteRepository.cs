﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace Api.JetNett.ServiceStackApi
{
    public class OrmLiteRepository<T> : Service, IRepository<T> where T : class, new()
    {
        public virtual T GetById(int id)
        {
            return Db.GetById<T>(id);
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