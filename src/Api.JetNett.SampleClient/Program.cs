using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using JetNettApiReactive;
using ServiceStack;
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

            var client = new JsonServiceClient("http://dev.jetnett.com");

            var repo = new PagesRepository(client);

            var obs = repo.GetById(8);


            obs.Subscribe(x =>
            {
                Console.WriteLine(x.Title);
            });

            obs.Wait();
            

            Console.Read();
        }

        //Session ID, Journal ID, Task Id
        //----null--, ---7------,  6
        //NoteType
        // 5 = session, 2 = Journal, 3 = Task
        //
        //PK ID
        // WHERE Notes.Type == Session && Notes.ParentTypeId = 5
    }
}
