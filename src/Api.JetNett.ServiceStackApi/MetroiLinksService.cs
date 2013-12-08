using System.Collections.Generic;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;

namespace Api.JetNett.ServiceStackApi
{
    public class MetroILinksService : JetNettService<MetroiLinksDTO, MetroiLinks>
    {
        public MetroILinksService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }
       
        public override IEnumerable<MetroiLinks> Get(MetroiLinksDTO requestDto)
        {
            return requestDto.ClientId != default(int) 
                ? Repository.Where(m => m.ClientId == requestDto.ClientId) 
                : base.Get(requestDto);
        }
    }
}