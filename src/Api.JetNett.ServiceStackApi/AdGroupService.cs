using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using ServiceStack.Data;

namespace Api.JetNett.ServiceStackApi
{
    public sealed class AdGroupService : JetNettService<AdGroupsDTO,AdGroup>
    {
        OrmLiteRepository<AdPageRelationship> RelationshipRepository { get; set; }
        public AdGroupService(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
            RelationshipRepository = new OrmLiteRepository<AdPageRelationship>(Db);
        }

        public override IEnumerable<AdGroup> Get(AdGroupsDTO request)
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
                return null;
            }

            if (request.PageId != default(int))
            {
                var relationshipEntry = RelationshipRepository.Where(i => i.PageId == request.PageId).FirstOrDefault();

                return relationshipEntry == null ? null : Repository.GetByIds(relationshipEntry.AdGroup.GetValueOrDefault().ToEnumerable());
            }

            if (request.ClientId != default(int))
            {
                var relationshipEntry = RelationshipRepository.Where(i => i.ClientId == request.ClientId).FirstOrDefault();

                if (relationshipEntry == null)
                    return null;

                return Repository.GetByIds(relationshipEntry.AdGroup.GetValueOrDefault().ToEnumerable());
            }

            return base.Get(request);
        }

        IEnumerable<AdGroup> MakeResponse(AdPageRelationship adPageRelationship)
        {
            return Repository.GetByIds(adPageRelationship.AdGroup.GetValueOrDefault(0).ToEnumerable());
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