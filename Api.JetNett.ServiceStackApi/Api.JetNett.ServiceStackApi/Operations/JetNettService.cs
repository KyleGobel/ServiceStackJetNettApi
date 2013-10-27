using System;
using System.Globalization;
using System.Net;
using Api.JetNett.Models.Contracts;
using ServiceStack.Common;
using ServiceStack.Common.Web;

namespace Api.JetNett.ServiceStackApi.Operations
{
    public class JetNettService<TRequest, TResponse, TModel> : OrmLiteRepository<TModel>
        where TRequest : IRequestDTO<TModel>
        where TResponse : IResponseDTO<TModel>, new()
        where TModel : class, new()
    {
        /// <summary>
        /// GET /metroilinks/{Id}
        /// GET /metroilinks
        /// </summary>
        public TResponse Get(TRequest request)
        {
            if (request.Id == default(int)) {
                return new TResponse {
                    Entities = GetAll()
                };
            }

            return new TResponse {
                Entity = GetById(request.Id)
            };
        }

        /// <summary>
        /// POST /metroilinks
        ///
        /// returns HTTP response =>
        /// 201 Created
        /// Location: http://hostapi/metroilinks/{newMetroiLinksId}
        /// </summary>
        public object Post(TModel entity)
        {
            var id = Insert(entity);

            var newEntity = new TResponse {
                Entity = GetById(Convert.ToInt32(id))
            };

            return new HttpResult(newEntity) {
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
        public object Put(TRequest request)
        {
            Update(request.Entity);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                       { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(request.Id.ToString(CultureInfo.InvariantCulture))}
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
        public object Delete(TRequest request)
        {
            Delete(request.Id);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                          { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(request.Id.ToString(CultureInfo.InvariantCulture)) } 
                       }
            };
        }
    }
}