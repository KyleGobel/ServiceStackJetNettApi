using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    public interface IGetRequestDTO
    {
        int[] Ids { get; set; }
    }


    [Route("/badlink/{Ids}")]
    [Route("/badlink")]
    public class BadLinksDTO : IGetRequestDTO, IReturn<IEnumerable<BadLink>>
    {
        public int[] Ids { get; set; }

        public BadLinksDTO(params int[] ids)
        {
            this.Ids = ids;
        }
    }
}