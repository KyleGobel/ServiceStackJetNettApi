using System.Collections.Generic;
using System.Linq;
using Api.Jetnett.Models.Models;
using Api.Jetnett.Models.TableMappings;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace Api.JetNett.ServiceStackApi
{
    public class ClientService : Service
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public object Any(ClientQuery request)
        {
            if (request.Id != default(int))
            {
                return GetById(request.Id);
            }

            if (request.Username != default(string) && request.Password != default(string))
            {
                return GetByUsernamePassword(request.Username, request.Password);
            }

            return GetAll();
            return "Invalid Query Object Values";
        }

        private List<Client> GetAll()
        {
            return null;
        }
        private Client GetById(int id)
        {
            Client response = null;
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                response = db.GetById<Client>(id);
            }
            return response;
        }
        private Client GetByUsernamePassword(string username, string password)
        {
            Clients response = null;
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                response = db.Where<Clients>(c => c.User_ID == username && c.Password == password).SingleOrDefault();
            }
            return response.ToEntity();
        }
    }
}