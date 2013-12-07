using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class ZipcodeService : JetNettService<CommunityZipcodesRequestDTO,CommunityZipcodesResponseDTO,CommunityZipcodes>
    {
        public ZipcodeService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override CommunityZipcodesResponseDTO Get(CommunityZipcodesRequestDTO request)
        {
            if (request.PageId != default(int))
            {
                return new CommunityZipcodesResponseDTO {
                    Entity = Repository.Where(x => x.PageId == request.PageId).SingleOrDefault()
                };
            }
            return base.Get(request);
        }
    }
}