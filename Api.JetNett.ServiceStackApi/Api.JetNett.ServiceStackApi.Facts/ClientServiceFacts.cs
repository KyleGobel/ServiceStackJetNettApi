using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Contracts;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Operations;
using Moq;
using Ploeh.AutoFixture;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using Xunit;

namespace Api.JetNett.ServiceStackApi.Facts
{
    public class TestEntity
    { }
    public class TestRequestDTO : IRequestDTO<TestEntity>
    {
        public int Id { get; set; }
        public TestEntity Entity { get; set; }
    }
    public class TestResponseDTO : IResponseDTO<TestEntity>
    {
        public TestEntity Entity { get; set; }
        public List<TestEntity> Entities { get; set; }
    }

    public class JetNettServiceFacts
    {
        public Fixture Fixture { get; set; }
        public JetNettServiceFacts()
        {
           Fixture = new Fixture(); 
        }

        Mock<OrmLiteRepository<TestEntity>> CreateTestRepository(List<TestEntity> testData = null)
        {
            if (testData == null)
                testData = Fixture.CreateMany<TestEntity>().ToList();
            var mockTestRepository = new Mock<OrmLiteRepository<TestEntity>>(null);

            mockTestRepository.Setup(i => i.GetAll()).Returns(testData);
            mockTestRepository.Setup(i => i.GetById(It.IsAny<int>())).Returns(Fixture.Create<TestEntity>());
            mockTestRepository.Setup(i => i.Insert(It.IsAny<TestEntity>())).Returns(Fixture.Create<int>());

            return mockTestRepository;
        }
        public class TheGetMethod : JetNettServiceFacts
        {
            [Fact]
            public void ShouldFillEntitiesPropertyOfDTOWhenCalledWithDefaultTModelId()
            {
                //arrange
                var testData = Fixture.CreateMany<TestEntity>().ToList();
                var mockRepository = CreateTestRepository(testData);

                var service = new JetNettService<
                    TestRequestDTO, 
                    TestResponseDTO, 
                    TestEntity>
                    (null, mockRepository.Object);

                //act
                var responseDTO = service.Get(new TestRequestDTO { Id = 0 });


                //assert
                Assert.NotNull(responseDTO);
                mockRepository.Verify(i=> i.GetAll(),Times.Once());
                Assert.Equal(testData, responseDTO.Entities);
            }

            [Fact]
            public void ShouldFillEntityPropertyOfDTOWhenCalledWithNonDefaultTModelId()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var service = new JetNettService<
                   TestRequestDTO,
                   TestResponseDTO,
                   TestEntity>
                   (null, mockRepository.Object);

                //act 
                var responseDTO = service.Get(new TestRequestDTO() { Id = Fixture.Create<int>() });

                //assert
                Assert.NotNull(responseDTO);
                mockRepository.Verify(i => i.GetById(It.IsAny<int>()), Times.Once());
                Assert.NotNull(responseDTO.Entity);
            }
        }

        public class ThePostMethod :JetNettServiceFacts
        {
            [Fact]
            public void ShouldReturnACreatedHttpResponse()
            {
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(f => f.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                  TestRequestDTO,
                  TestResponseDTO,
                  TestEntity>
                  (null, mockRepository.Object,mockRc.Object);

                var response = (HttpResult)service.Post(Fixture.Create<TestEntity>());

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
                Assert.IsType(typeof(TestResponseDTO), response.Response);
            }

             [Fact]
            public void ShouldInsertAnEntity()
            {
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(f => f.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                  TestRequestDTO,
                  TestResponseDTO,
                  TestEntity>
                  (null, mockRepository.Object,mockRc.Object);

                 var response = (HttpResult)service.Post(Fixture.Create<TestEntity>());

                 //assert the repos insert method was called
                 mockRepository.Verify(r => r.Insert(It.IsAny<TestEntity>()), Times.Once);
            }
        }
    }
}