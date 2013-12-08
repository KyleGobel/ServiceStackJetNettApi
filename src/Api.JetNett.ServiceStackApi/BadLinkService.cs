using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class BadLinkService : JetNettService<BadLinksDTO,  BadLink>
    {
        public BadLinkService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }
    }
}