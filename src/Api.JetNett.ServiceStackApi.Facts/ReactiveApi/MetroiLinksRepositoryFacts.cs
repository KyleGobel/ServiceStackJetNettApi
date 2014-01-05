using System.Net;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using JetNettApiReactive;
using ServiceStack;
using Xunit;

namespace Api.JetNett.ServiceStackApi.Facts.ReactiveApi
{
    public class MetroiLinksRepositoryFacts : IUseFixture<TestDb>
    {
       #region Setup
        MetroiLinkRepository ReactiveRepo { get; set; }
        TestDb TestDatabase { get; set; }
        public MetroiLinksRepositoryFacts()
        {
            var serviceClient = new JsonServiceClient(TestConfig.DevHostBaseUrl);
            serviceClient.Credentials = new NetworkCredential("ApiUser", "ssapi");
            ReactiveRepo = new MetroiLinkRepository(serviceClient);
        }
        public void SetFixture(TestDb data)
        {
            TestDatabase = data;
        }
        #endregion

        [Fact]
        public void CanUpdate()
        {
            MetroiLinks iLink = new MetroiLinks();
            ReactiveRepo.Update(iLink);
        }
    }

}