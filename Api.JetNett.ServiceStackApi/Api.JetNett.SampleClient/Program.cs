using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.JetNett.Models.Operations;
using RestSharp;
using ServiceStack.ServiceClient.Web;

namespace Api.JetNett.SampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
        //    var client = new RestClient("http://localhost:9037");

        //    var request = new RestRequest("metroilinks/{id}", Method.GET);
        //    request.AddUrlSegment("id", "907");

        //    var response = client.Execute<MetroiLinksResponse>(request);

            var client = new JsonServiceClient("http://localhost:9037");

            var response = client.Get(new MetroiLinksQuery { ClientId = 907 });



            Console.Read();

        }
    }
}
