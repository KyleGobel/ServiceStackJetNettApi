using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ServiceStack;

namespace JetNettApiReactive
{
    public abstract class BaseReactiveRepository<T> : IReactiveRepository<T> where T : class
    {
        protected JsonServiceClient JsonClient { get; set; }
        protected TimeSpan Timeout { get; set; }
        protected BaseReactiveRepository(JsonServiceClient client, int timeoutInSeconds = 5)
        {
            Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            JsonClient = client;
        }
        public IObservable<int> Add(T entity)
        {
            return JsonClient.PostAsync<int>(entity).ToObservable().Timeout(Timeout);
        }

        public abstract IObservable<List<T>> GetAll();

        public abstract void Delete(int id);

        public abstract void Update(T entity);

        public abstract IObservable<T> GetById(int id);

        public abstract IObservable<List<T>> GetByIds(params int[] ids);
    }
}