using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;

namespace Api.JetNett.ServiceStackApi
{
    public class PagesService : JetNettService<PagesRequestDTO,PagesResponseDTO,Page>
    { 
        public PagesService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }
        
    }
}