using System.Collections.Generic;
using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Facts.Common;
using Moq;
using Ploeh.AutoFixture;

using Xunit;

namespace Api.JetNett.ServiceStackApi.Facts
{
    public class ClientServiceFacts
    {
        protected Fixture Fixture { get; set; }

        public ClientServiceFacts()
        {
            Fixture = new Fixture();
        }
        Mock<IRepository<Client>> CreateTestRepository(List<Client> testData = null)
        {
            testData = testData ??  Fixture.CreateMany<Client>().ToList();
            var mockTestRepository = new Mock<IRepository<Client>>();

            mockTestRepository.Setup(i => i.GetAll()).Returns(testData);
            mockTestRepository.Setup(i => i.GetByIds(It.IsAny<IEnumerable<int>>())).Returns((IEnumerable<int> x) => testData.Where(td => x.Contains(td.Id)));
            mockTestRepository.Setup(i => i.Insert(It.IsAny<Client>())).Returns((Client x) => x.Id);
            mockTestRepository.Setup(i => i.Update(It.IsAny<Client>()));
            mockTestRepository.Setup(i => i.Delete(It.IsAny<IEnumerable<int>>()));

            return mockTestRepository;
        }
        [Fact]
        public void ClientByIdsFindsMultipleMatchingResults()
        {
            var service = new ClientService(null, CreateTestRepository().Object);

            var clients = service.Get(new ClientsDTO(1, 2, 3, 4, 5));

            Assert.NotNull(clients);

        }
    }
}