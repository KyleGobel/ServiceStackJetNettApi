using System;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack.Common.Web;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : OrmLiteRepository<Client>
    {
        public ClientResponse Get(ClientQuery request)
        {
            if (request.Id != default(int))
            {
                var client = GetById(request.Id);

                if (client == null)
                    throw new HttpError(HttpStatusCode.NotFound, new ArgumentException("Client does not exist: " + request.Id));

                return new ClientResponse { Client = client };
            }

            if (request.Username != default(string) && request.Password != default(string))
            {
                var client = Where(
                        c => c.UserId == request.Username
                        && c.Password == request.Password)
                        .SingleOrDefault();

                if (client == null)
                    throw new HttpError(HttpStatusCode.NotFound, new ArgumentException("Client does not exist with those credentials.  Username: " + request.Username));

                return new ClientResponse
                {
                    Client = client
                };
            }

            return new ClientResponse { Clients = GetAll() };
        }
    }
}