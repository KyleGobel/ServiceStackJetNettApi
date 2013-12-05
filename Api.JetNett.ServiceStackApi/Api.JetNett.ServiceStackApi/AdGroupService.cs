using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Api.JetNett.ServiceStackApi
{
    public sealed class AdGroupService : JetNettService<AdGroupRequestDTO,AdGroupResponseDTO,AdGroup>
    {
        OrmLiteRepository<AdPageRelationship> RelationshipRepository { get; set; }
        public AdGroupService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
            RelationshipRepository = new OrmLiteRepository<AdPageRelationship>(Db);
        }

        public override AdGroupResponseDTO Get(AdGroupRequestDTO request)
        {
            if (request.ClientId != default(int) && request.PageId != default(int))
            {
                //attempt to get by both client and page
                var entry = RelationshipRepository.Where(
                    i => i.ClientId == request.ClientId && i.PageId == request.PageId)
                    .SingleOrDefault();

                if (entry != null)
                    return MakeResponse(entry);

                //attempt by just page
                entry = GetByPageId(request.PageId);
                
                if (entry != null)
                    return MakeResponse(entry);

                //attempt by just client
                entry = GetByClientId(request.ClientId);

                if (entry != null)
                    return MakeResponse(entry);

                //nothing found
                return new AdGroupResponseDTO();
            }

            if (request.PageId != default(int))
            {
                var relationshipEntry = RelationshipRepository.Where(i => i.PageId == request.PageId).FirstOrDefault();

                if (relationshipEntry == null)
                    return new AdGroupResponseDTO();

                return new AdGroupResponseDTO {
                        Entity = Repository.GetById(relationshipEntry.AdGroup.GetValueOrDefault())
                };
            }

            if (request.ClientId != default(int))
            {
                var relationshipEntry = RelationshipRepository.Where(i => i.ClientId == request.ClientId).FirstOrDefault();

                if (relationshipEntry == null)
                    return new AdGroupResponseDTO();

                return new AdGroupResponseDTO {
                        Entity = Repository.GetById(relationshipEntry.AdGroup.GetValueOrDefault())
                };
            }

            return base.Get(request);
        }

        AdGroupResponseDTO MakeResponse(AdPageRelationship adPageRelationship)
        {
            return new AdGroupResponseDTO { Entity = Repository.GetById(adPageRelationship.AdGroup.GetValueOrDefault(0)) };
        }

        private AdPageRelationship GetByClientId(int clientId)
        {
            return RelationshipRepository.Where(i => i.ClientId == clientId).FirstOrDefault(); 
        }

        private AdPageRelationship GetByPageId(int pageId)
        {
            return RelationshipRepository.Where(i => i.PageId == pageId).FirstOrDefault(); 
        }
    }
}