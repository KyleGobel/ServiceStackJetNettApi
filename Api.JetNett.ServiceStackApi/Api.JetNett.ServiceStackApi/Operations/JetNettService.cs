using System;
using System.Data;
using System.Globalization;
using System.Net;
using Api.JetNett.Models.Contracts;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace Api.JetNett.ServiceStackApi.Operations
{
    public class JetNettService<TRequest, TResponse, TModel> : Service
        where TRequest : IRequestDTO<TModel>
        where TResponse : IResponseDTO<TModel>, new()
        where TModel : class, new()
    {
        protected OrmLiteRepository<TModel> Repository { get; set; } 
        public JetNettService(IDbConnectionFactory dbConnectionFactory) 
        {
            Repository = new OrmLiteRepository<TModel>(dbConnectionFactory.CreateDbConnection());
        }
        /// <summary>
        /// GET /metroilinks/{Id}
        /// GET /metroilinks
        /// </summary>
        public virtual TResponse Get(TRequest request)
        {
            if (request.Id == default(int)) {
                return new TResponse {
                    Entities = Repository.GetAll()
                };
            }

            return new TResponse {
                Entity = Repository.GetById(request.Id)
            };
        }

        /// <summary>
        /// POST /metroilinks
        ///
        /// returns HTTP response =>
        /// 201 Created
        /// Location: http://hostapi/metroilinks/{newMetroiLinksId}
        /// </summary>
        public virtual object Post(TModel entity)
        {
            var id = Repository.Insert(entity);

            var newEntity = new TResponse {
                Entity = Repository.GetById(Convert.ToInt32(id))
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
        public virtual object Put(TRequest request)
        {
            Repository.UpdateEntity(request.Entity);

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
        public virtual object Delete(TRequest request)
        {
            Repository.DeleteById(request.Id);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                          { HttpHeaders.Location, this.RequestContext.AbsoluteUri.CombineWith(request.Id.ToString(CultureInfo.InvariantCulture)) } 
                       }
            };
        }
    }
}