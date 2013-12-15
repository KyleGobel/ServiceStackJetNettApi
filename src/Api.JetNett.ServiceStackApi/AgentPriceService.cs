using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Types;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{

    [Route("/agentPrice")]
    [Route("/agentPrice/{Id}")]
    public class AgentPriceDTO : IReturn<List<AgentPrice>>
    {
        public int Id { get; set; }
    }
    public class AgentPriceService : Service
    {
        protected OrmLiteRepository<AgentPrice> Repository { get; set; }
        public AgentPriceService(IDbConnectionFactory dbConnectionFactory)
        {
            Repository = new OrmLiteRepository<AgentPrice>(dbConnectionFactory.Open());
        }

        public List<AgentPrice> Get(AgentPriceDTO request)
        {
            if (request.Id == default(int))
                return Repository.GetAll().ToList();
            return Repository.GetByIds(request.Id.ToEnumerable()).ToList();
        }

        
    }

}