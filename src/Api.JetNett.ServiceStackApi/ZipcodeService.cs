using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;

namespace Api.JetNett.ServiceStackApi
{
    public class ZipcodeService : JetNettService<CommunityZipcodesDTO,CommunityZipcodes>
    {
        public ZipcodeService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override IEnumerable<CommunityZipcodes> Get(CommunityZipcodesDTO request)
        {
            if (request.PageId != default(int))
            {
                return Repository
                    .Where(x => x.PageId == request.PageId)
                    .SingleOrDefault().ToEnumerable();
            }

            return base.Get(request);
        }
    }
}