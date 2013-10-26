using Api.Jetnett.Models.Operations;
using Api.Jetnett.Models.Types;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : OrmLiteRepository<Client>
    {
        public ClientResponse Get(ClientQuery request)
        {
            if (request.Id != default(int))
            {
                return new ClientResponse { Client = GetById(request.Id) };
            }

            if (request.Username != default(string) && request.Password != default(string))
            {
                return new ClientResponse
                {
                    Client = GetWhere(
                        c => c.UserId == request.Username
                        && c.Password == request.Password)
                };
            }

            return new ClientResponse { Clients = GetAll() };
        }
    }
}