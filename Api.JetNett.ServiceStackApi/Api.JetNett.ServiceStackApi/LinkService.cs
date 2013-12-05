using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class LinkService : JetNettService<LinkRequestDTO,LinkResponseDTO,Link>
    {
        public LinkService(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
 
        }

        public override LinkResponseDTO Get(LinkRequestDTO request)
        {
            if (request.PageId != default(int))
            {
                return new LinkResponseDTO {
                    Entities = Repository.Where(i => i.PageId == request.PageId)
                };
            }
            return base.Get(request);
        } 
    }
}