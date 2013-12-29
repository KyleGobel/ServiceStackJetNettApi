using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace JetNettApiReactive
{
    public class MetroiLinkRepository : BaseReactiveRepository<MetroiLinks>
    {
        public MetroiLinkRepository(JsonServiceClient client, int timeoutInSeconds = 5) : base(client, timeoutInSeconds)
        { }

        public override IObservable<List<MetroiLinks>> GetAll()
        {
            return JsonClient.GetAsync(new ListMetroiLinksRequest()).ToObservable().Timeout(Timeout);
        }

        public override void Delete(int id)
        {
            JsonClient.Delete(new DeleteMetroiLinksRequest(id));
        }

        public IObservable<MetroiLinks> GetByClientId(int clientId)
        {
            return JsonClient.GetAsync(new GetMetroiLinksFromClientIdRequest(clientId)).ToObservable().Timeout(Timeout);
        }
        public override void Update(MetroiLinks entity)
        {
            JsonClient.Put(new UpdateMetroiLinksRequest(entity));
        }

        public override IObservable<MetroiLinks> GetById(int id)
        {
            return JsonClient.GetAsync(new GetMetroiLinksRequest(id)).ToObservable().Timeout(Timeout);
        }

        public override IObservable<List<MetroiLinks>> GetByIds(params int[] ids)
        {
            return JsonClient.GetAsync(new ListMetroiLinksRequest {Ids = ids}).ToObservable().Timeout(Timeout);
        }
    }
}