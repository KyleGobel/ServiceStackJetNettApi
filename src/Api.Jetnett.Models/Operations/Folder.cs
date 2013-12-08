using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/folder/{Ids}")]
    [Route("/folder")]
    [Route("/folder/children/{ParentId}")]
    public class FoldersDTO : IGetRequestDTO, IReturn<List<Folder>>
    {
        public FoldersDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int[] Ids { get; set; }

        public int ParentId { get; set; }
    }

  
}
