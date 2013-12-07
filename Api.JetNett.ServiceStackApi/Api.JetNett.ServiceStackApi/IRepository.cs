using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.JetNett.ServiceStackApi
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetByIds(IEnumerable<int> id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> whereExpression);
        long Insert(T entity);
        void Update(T entity);
        void Delete(IEnumerable<int> id);
    }
}