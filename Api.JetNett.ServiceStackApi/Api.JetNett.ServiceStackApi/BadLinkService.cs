using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;

namespace Api.JetNett.ServiceStackApi
{
    public class BadLinkService : JetNettService<BadLinkRequestDTO, BadLinkResponseDTO, BadLink>
    {
        public BadLinkService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }
    }
}