using System.Collections.Generic;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace Api.JetNett.Models.Operations
{
    [Route("/client/{Ids}", "GET")]
    [Route("/client", "GET")]
    [Route("/client/{Username}/{Password}", "GET")]
    public class ClientsDTO : IGetRequestDTO ,IReturn<List<Client>>
    {
        public ClientsDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public int[] Ids { get; set; }
    }
}