using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Web;

namespace Api.JetNett.ServiceStackApi.Operations
{
    public class JetNettService<TGetRequest, TModel> : Service
        where TGetRequest : IGetRequestDTO
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
        public virtual IEnumerable<TModel> Get(TGetRequest request)
        {
            return (request.Ids == null || request.Ids.Length == 0 )? Repository.GetAll() : Repository.GetByIds(request.Ids);
        }

        /// <summary>
        /// POST /metroilinks
        ///
        /// returns HTTP response =>
        /// 201 Created
        /// Location: http://hostapi/service/{newMetroiLinksId}
        /// </summary>
        public virtual object Post(TModel entity)
        {
            var id = Repository.Insert(entity);

            var newEntity = Repository.GetByIds(Convert.ToInt32(id).ToEnumerable());

            return new HttpResult(newEntity)
            {
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
        public virtual object Put(TModel entity)
        {
            Repository.Update(entity);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                       { HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(entity.GetId()) }
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
        public virtual object Delete(TModel entity)
        {
            Repository.Delete(((int)entity.GetId()).ToEnumerable());


            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                          { HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(entity.GetId()) } 
                       }
            };
        }
    }
}