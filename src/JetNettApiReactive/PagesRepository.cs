using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace JetNettApiReactive
{
    public class PagesRepository : IReactiveRepository<Page>
    {
        protected JsonServiceClient JsonClient { get; private set; }
        protected TimeSpan Timeout { get; set; }
        
        public PagesRepository(JsonServiceClient client, int timeoutInSeconds = 5)
        {
            Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            JsonClient = client;
        }

        public IObservable<int> Add(Page page)
        {
            return JsonClient.PostAsync<int>(page).ToObservable().Timeout(Timeout);
        }

        public IObservable<List<Page>> GetAll()
        {
            return JsonClient.GetAsync(new ListPagesRequest()).ToObservable().Timeout(Timeout);
        }

        public IObservable<List<Page>> GetByFolderId(int folderId)
        {
            return JsonClient.GetAsync(new ListPagesRequest {FolderId = folderId}).ToObservable().Timeout(Timeout);
        }

        public IObservable<List<Page>> GetPagePath(params int[] pageIds)
        {
            return JsonClient.GetAsync(new PagesWithPathsAsTitles(pageIds)).ToObservable().Timeout(Timeout);
        }

        public void Delete(int id)
        {
            JsonClient.Delete(new DeletePageRequest(id));
        }

        public void Update(Page entity)
        {
            JsonClient.Put(new UpdatePageRequest(entity.Id, entity));
        }

        public IObservable<Page> GetById(int id)
        {
            return JsonClient.GetAsync(new GetPageRequest(id)).ToObservable().Timeout(Timeout);
        }

        public IObservable<List<Page>> GetByIds(params int[] ids)
        {
            return JsonClient.GetAsync(new ListPagesRequest {Ids = ids}).ToObservable().Timeout(Timeout);
        }
    }
}