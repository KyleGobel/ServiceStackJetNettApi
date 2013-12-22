using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    
    public class ClientsService : Service
    {
        protected OrmLiteRepository<Client> Repository { get; set; }

        public ClientsService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<Client>(dbConnectionFactory.Open());
        }


        public Client Get(GetClientRequest request)
        {
            if (request.Username != default(string) && request.Password != default(string))
                return
                    Repository.Where(x => x.UserId == request.Username && x.Password == request.Password)
                        .SingleOrDefault();
            return Repository.GetById(request.Id);
        }

        public List<Client> Get(ListClientsRequest request)
        {
            if (request.Ids != default(int[]))
                return Repository.GetByIds(request.Ids).ToList();
            return Repository.GetAll().ToList();
        }

        public void Put(UpdateClientRequest request)
        {
            Repository.Update(request.Entity);
        }

        public void Delete(DeleteClientRequest request)
        {
            Repository.Delete(request.Id.ToEnumerable());
        }

        public int Post(InsertClientRequest request)
        {
            return (int)Repository.Insert(request.Entity);
        }
    }
}