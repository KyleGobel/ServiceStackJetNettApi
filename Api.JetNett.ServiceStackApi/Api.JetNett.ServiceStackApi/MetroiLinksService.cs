using System.Data;
using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class MetroILinksService : JetNettService<MetroiLinkRequestDTO, MetroiLinksResponseDTO, MetroiLinks>
    {
        public MetroILinksService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }
        /// <summary>
        /// GET
        /// 
        /// This GET takes care of getting by clientId
        /// http://hostapi/metroilinks/client/{clientId}
        /// </summary>
        public override MetroiLinksResponseDTO Get(MetroiLinkRequestDTO requestDto)
        {
            if (requestDto.ClientId != default(int)) {
                return new MetroiLinksResponseDTO {
                    Entity = Repository.Where(m => m.ClientId == requestDto.ClientId).SingleOrDefault()
                };
            }

            return base.Get(requestDto);
        }
    }
}