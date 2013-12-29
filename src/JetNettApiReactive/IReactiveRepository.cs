using System;
using System.Collections.Generic;

namespace JetNettApiReactive
{
    public interface IReactiveRepository<TEntity> where TEntity : class
    {
        IObservable<int> Add(TEntity entity);
        IObservable<List<TEntity>> GetAll();
        void Delete(int id);
        void Update(TEntity entity);
        IObservable<TEntity> GetById(int id);
        IObservable<List<TEntity>> GetByIds(params int[] ids);

    }
}