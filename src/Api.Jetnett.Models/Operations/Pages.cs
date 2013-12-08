using System.Collections.Generic;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
        [Route("/page/{Ids}")]
        [Route("/page")]
        [Route("/page/folder/{folderId}")]
        [Route("/page/path/{pathPageId}")]
        public class PagesDTO : IGetRequestDTO, IReturn<List<Page>>
        {
            public PagesDTO(params int[] ids)
            {
                this.Ids = ids;
            }
            public int[] Ids { get; set; }
            public int PathPageId { get; set; }
            public int FolderId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
}