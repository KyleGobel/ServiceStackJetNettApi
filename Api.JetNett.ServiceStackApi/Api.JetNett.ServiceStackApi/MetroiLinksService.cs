using System;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack.Common.Web;

namespace Api.JetNett.ServiceStackApi
{
    public class MetroiLinksService : OrmLiteRepository<MetroiLinks>
    {
        public MetroiLinksResponse Get(MetroiLinksQuery request)
        {
            if (request.Id != default(int))
            {
                var mil = GetById(request.Id);
                if (mil == null)
                    throw new HttpError(HttpStatusCode.NotFound, new ArgumentException("Metro iLinks not found: " + request.Id));

                return new MetroiLinksResponse { MetroiLink = mil };
            }
            if (request.ClientId != default(int))
            {
                var mil = Where(i => i.ClientId == request.ClientId).SingleOrDefault();
                if (mil == null)
                    throw new HttpError(HttpStatusCode.NotFound, new ArgumentException("Metro iLinks not found.  ClientID: " + request.ClientId));

                return new MetroiLinksResponse { MetroiLink = mil };               
            }

            return new MetroiLinksResponse { MetroiLinks = GetAll() };
        }
    }
}