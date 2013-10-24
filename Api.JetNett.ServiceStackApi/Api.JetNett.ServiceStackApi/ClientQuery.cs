using Api.Jetnett.Models.Models;
using ServiceStack.ServiceHost;

namespace Api.JetNett.ServiceStackApi
{
    [Route("/client", "GET")] //Returns All
    [Route("/client/{Id}")] //Returns 1
    [Route("/client/{Username}/{Password}")] //Returns 1
    public class ClientQuery :IReturn<Client>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}