using System;
using System.Globalization;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using ServiceStack.Common;
using ServiceStack.Common.Web;

namespace Api.JetNett.ServiceStackApi
{
    public class MetroiLinkService : OrmLiteRepository<MetroiLinks>
    {
        /// <summary>
        /// GET /metroilinks/{Id}
        /// GET /metroilinks
        /// </summary>
        public MetroiLinkResponse Get(MetroiLinkRequest request)
        {
            if (request.Id == default(int)) {
                return new MetroiLinkResponse {
                        MetroiLinks = GetAll()
                    };
            }

            return new MetroiLinkResponse {
                MetroiLink = GetById(request.Id)
            };
        }

        /// <summary>
        /// POST /metroilinks
        ///
        /// returns HTTP response =>
        /// 201 Created
        /// Location: http://hostapi/metroilinks/{newMetroiLinksId}
        /// </summary>
        public object Post(MetroiLinks metroiLink)
        {
            var id = Insert(metroiLink);

            var newMetroiLink = new MetroiLinkResponse {
                MetroiLink = GetById(Convert.ToInt32(id))
            };

            return new HttpResult(newMetroiLink) {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                            { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(id.ToString(CultureInfo.InvariantCulture)) }
                        }
            };
        }

        /// <summary>
        /// PUT /metroilinks/{Id}
        /// 
        /// returns HTTP response =>
        /// 204 No Content
        /// Location: http://hostapi/metroilinks/{id}
        /// </summary>
        public object Put(MetroiLinkRequest metroiLinksQuery)
        {
            Update(metroiLinksQuery.MetroiLink);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                       { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(metroiLinksQuery.MetroiLink.Id.ToString(CultureInfo.InvariantCulture))}
                   }
            };
        }

        /// <summary>
        /// DELETE /metroilinks/{Id}
        /// 
        /// return HTTP response =>
        /// 204 No Content
        /// Location: http://hostapi/metroilinks/{id}
        /// </summary>
        public object Delete(MetroiLinkRequest metroILinksQuery)
        {
            Delete(metroILinksQuery.MetroiLink.Id);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                          { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(metroILinksQuery.MetroiLink.Id.ToString(CultureInfo.InvariantCulture)) } 
                       }
            };
        }

    }
}