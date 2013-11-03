using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public class AdGroupService : JetNettService<AdGroupRequestDTO,AdGroupResponseDTO,AdGroup>
    {
        public AdGroupService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        { }

        public override AdGroupResponseDTO Get(AdGroupRequestDTO request)
        {
            var relationshipRepository = new OrmLiteRepository<AdPageRelationship>(Db);
            if (request.ClientId != default(int) && request.PageId != default(int))
            {
                var relationshipEntry = relationshipRepository.Where(
                    i => i.ClientId == request.ClientId && i.PageId == request.PageId)
                    .SingleOrDefault();

                if (relationshipEntry == null)
                    return new AdGroupResponseDTO();

                return new AdGroupResponseDTO {
                    Entity = Repository.Where(i => i.Id == relationshipEntry.AdGroup).SingleOrDefault()
                };
            }

            if (request.PageId != default(int))
            {
                var relationshipEntry = relationshipRepository.Where(i => i.PageId == request.PageId).FirstOrDefault();

                if (relationshipEntry == null)
                    return new AdGroupResponseDTO();

                return new AdGroupResponseDTO {
                        Entity = Repository.GetById(relationshipEntry.AdGroup.GetValueOrDefault())
                };
            }

            if (request.ClientId != default(int))
            {
                var relationshipEntry = relationshipRepository.Where(i => i.ClientId == request.ClientId).FirstOrDefault();

                if (relationshipEntry == null)
                    return new AdGroupResponseDTO();

                return new AdGroupResponseDTO {
                        Entity = Repository.GetById(relationshipEntry.AdGroup.GetValueOrDefault())
                };
            }

            return base.Get(request);
        }
    }
}