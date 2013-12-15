using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : JetNettService<ClientsDTO,Client>
    {
        public ClientService(IDbConnectionFactory dbConnectionFactory, IRepository<Client> clientRepository = null)
            : base(dbConnectionFactory, clientRepository)
        { }
    }

}