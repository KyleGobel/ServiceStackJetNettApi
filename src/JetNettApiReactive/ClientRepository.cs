using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace JetNettApiReactive
{
    public class ClientRepository : BaseReactiveRepository<Client>
    {
        public ClientRepository(JsonServiceClient client, int timeoutInSeconds = 5) : base(client, timeoutInSeconds)
        { }

        public override IObservable<List<Client>> GetAll()
        {
            return JsonClient.GetAsync(new ListClientsRequest()).ToObservable().Timeout(Timeout);
        }

        public override void Delete(int id)
        {
            JsonClient.Delete(new DeleteClientRequest(id));
        }

        public override void Update(Client entity)
        {
            JsonClient.Put(new UpdateClientRequest(entity));
        }

        public override IObservable<Client> GetById(int id)
        {
            return JsonClient.GetAsync(new GetClientRequest(id)).ToObservable().Timeout(Timeout);
        }

        public override IObservable<List<Client>> GetByIds(params int[] ids)
        {
            return JsonClient.GetAsync(new ListClientsRequest {Ids = ids}).ToObservable().Timeout(Timeout);
        }
    }

}