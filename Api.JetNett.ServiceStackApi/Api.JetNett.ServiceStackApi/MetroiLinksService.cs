using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;

namespace Api.JetNett.ServiceStackApi
{
    public class MetroILinksService : JetNettService<MetroiLinkRequestDTO, MetroiLinksResponseDTO, MetroiLinks>
    {
        public MetroiLinksResponseDTO Get(MetroiLinkRequestDTO requestDto)
        {
            if (requestDto.ClientId != default(int))
            {
                return new MetroiLinksResponseDTO {
                    Entity = Where(m => m.ClientId == requestDto.ClientId).SingleOrDefault()
                };
            }

            return base.Get(requestDto);
        }
    }
}