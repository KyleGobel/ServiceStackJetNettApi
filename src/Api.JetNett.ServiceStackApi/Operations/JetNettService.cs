using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Mixins;
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Web;

namespace Api.JetNett.ServiceStackApi.Operations
{
    public class JetNettService<TRequest, TResponse, TModel> : Service
        where TRequest : IRequestDTO<TModel>
        where TResponse : IResponseDTO<TModel>, new()
        where TModel : class, new()
    {
        protected OrmLiteRepository<TModel> Repository { get; set; } 
        public JetNettService(IDbConnectionFactory dbConnectionFactory, OrmLiteRepository<TModel> repository = null, IRequest requestContext = null) 
        {
            //These are injectable for testin
            if (requestContext != null)
            {
               this.Request = requestContext; 
            }

            if (repository != null) {
                Repository = repository;
            }
            else {
                Repository = new OrmLiteRepository<TModel>(dbConnectionFactory.Open());
            }
        }

        /// <summary>
        /// GET /metroilinks/{Id}
        /// GET /metroilinks
        /// </summary>
        public virtual TResponse Get(TRequest request)
        {
            if (request.Ids != default(List<int>))
            {
               return new TResponse {
                   Entities = Repository.GetByIds(request.Ids)
               }; 
            }
          
            return new TResponse {
                Entities = Repository.GetAll()
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
                Entities = new List<TModel> { Repository.GetByIds(Convert.ToInt32(id).ToEnumerable()).SingleOrDefault() }
            };

            return new HttpResult(newEntity) {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                            { HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(id.ToString(CultureInfo.InvariantCulture)) }
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
            Repository.Update(request.Entity);

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                       { HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(request.Ids.Single().ToString(CultureInfo.InvariantCulture))}
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
            Repository.Delete(request.Ids);
            

            return new HttpResult {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                          { HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(request.Ids.ToString()) } 
                       }
            };
        }
    }
}