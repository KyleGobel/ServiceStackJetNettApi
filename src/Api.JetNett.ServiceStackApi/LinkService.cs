using System.Collections.Generic;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;

namespace Api.JetNett.ServiceStackApi
{
    public class LinkService : JetNettService<LinksDTO,Link>
    {
        public LinkService(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        { }

        public override IEnumerable<Link> Get(LinksDTO request)
        {
            return request.PageId != default(int) 
                ? Repository.Where(i => i.PageId == request.PageId) 
                : base.Get(request);
        }
    }
}