using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : JetNettService<ClientRequestDTO,ClientResponseDTO,Client>
    {
        public ClientService(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory)
        {
        }

    }

}