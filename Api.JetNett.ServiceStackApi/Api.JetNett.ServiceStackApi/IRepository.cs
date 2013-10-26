using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.JetNett.ServiceStackApi
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> whereExpression);
    }
}