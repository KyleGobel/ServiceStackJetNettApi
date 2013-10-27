using System.Data;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : JetNettService<ClientRequestDTO,ClientResponseDTO,Client>
    {
        ClientService(IDbConnection dbConnection) : base(dbConnection)
        {}
    }

}