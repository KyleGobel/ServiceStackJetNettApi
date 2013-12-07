using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.JetNett.Models.Mixins;
using Api.JetNett.ServiceStackApi.Facts.Common;
using Api.JetNett.ServiceStackApi.Operations;
using Moq;
using Ploeh.AutoFixture;
using ServiceStack;
using ServiceStack.Web;
using Xunit;

namespace Api.JetNett.ServiceStackApi.Facts
{
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
            mockTestRepository.Setup(i => i.GetByIds(It.IsAny<IEnumerable<int>>())).Returns((IEnumerable<int> x) => testData.Where(td => x.Contains(td.Id) ));
            mockTestRepository.Setup(i => i.Insert(It.IsAny<TestEntity>())).Returns((TestEntity x) => x.Id);
            mockTestRepository.Setup(i => i.Update(It.IsAny<TestEntity>()));
            mockTestRepository.Setup(i => i.Delete(It.IsAny<IEnumerable<int>>()));

            return mockTestRepository;
        }
        public class TheGetMethod : JetNettServiceFacts
        {
            [Fact]
            public void ShouldFillEntitiesPropertyOfDTOWhenCalledWithDefaultId()
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
                var responseDTO = service.Get(new TestRequestDTO());


                //assert
                Assert.NotNull(responseDTO);
                Assert.Equal(testData, responseDTO.Entities);
            }


         

            [Fact]
            public void ShouldCallReposGetAllWhenRequestDTOIdsIsDefault()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object);

                //act 
                service.Get(new TestRequestDTO());

                //assert
                mockRepository.Verify(r => r.GetAll(),Times.Once);
            }

        }

        public class ThePostMethod :JetNettServiceFacts
        {
            [Fact]
            public void ShouldReturnACreatedHttpResponse()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(f => f.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object, mockRc.Object);

                //act
                var response = (HttpResult)service.Post(Fixture.Create<TestEntity>());

                //assert
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            }

            [Fact]
            public void SouldReturnAResponseWithCorrectLocationHeader()
            {
                 //arrange
                var mockRepository = CreateTestRepository();
                var intInsertReturns = Fixture.Create<int>();
                mockRepository.Setup(i => i.Insert(It.IsAny<TestEntity>())).Returns(intInsertReturns);

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(f => f.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object,mockRc.Object);

                //act
                var response = (HttpResult)service.Post(Fixture.Create<TestEntity>());

                Assert.Equal("hostapi/testEntity/" + intInsertReturns, response.Headers["Location"]);
            }

            [Fact]
            public void ShouldInsertAnEntity()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(f => f.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object,mockRc.Object);

                var entityToInsert = Fixture.Create<TestEntity>();
                //act
                service.Post(entityToInsert);

                //assert the repos insert method was called
                mockRepository.Verify(r => r.Insert(entityToInsert), Times.Once);
            }
        }

        public class ThePutMethod : JetNettServiceFacts
        {
            [Fact]
            public void ShouldReturnAResponseWithCorrectLocationHeader()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdateRequest = Fixture.Build<TestRequestDTO>()
                  .With(x => x.Ids, Fixture.Create<int>().ToEnumerable()).Create();

                //act
                var response = (HttpResult)service.Put(entityToUpdateRequest);

                //assert
                Assert.Equal("hostapi/testEntity/" + entityToUpdateRequest.Ids.Single(), response.Headers["Location"]);
            }

            [Fact]
            public void ShouldUpdateTheEntity()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdateRequest = Fixture.Build<TestRequestDTO>()
                    .With(x => x.Ids, Fixture.Create<int>().ToEnumerable()).Create();

                //act
                service.Put(entityToUpdateRequest);

                //assert
                mockRepository.Verify(i => i.Update(entityToUpdateRequest.Entity), Times.Once);
            }

            [Fact]
            public void ShouldReturnANoContentHttpResponse()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdateRequest =
                    Fixture.Build<TestRequestDTO>().With(x => x.Ids, Fixture.Create<int>().ToEnumerable()).Create();

                //act
                var response = (HttpResult)service.Put(entityToUpdateRequest);

                //assert
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);               
            }
        }

        public class TheDeleteMethod : JetNettServiceFacts
        {
            [Fact] 
            public void ShouldDeleteAnEntry()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var requestContaingEntityToDelete = Fixture.Create<TestRequestDTO>();

                //act
                service.Delete(requestContaingEntityToDelete);

                //assert
                mockRepository.Verify(i => i.Delete(requestContaingEntityToDelete.Ids), Times.Once());
            }

            [Fact]
            public void ShouldReturnANoContentHttpResponse()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var requestContaingEntityToDelete = Fixture.Create<TestRequestDTO>();

                //act
                var response = (HttpResult)service.Delete(requestContaingEntityToDelete);

                //assert
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);    
            }

            [Fact]
            public void ShouldReturnAResponseWithCorrectLocationHeader()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequest>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var requestContaingEntityToDelete = Fixture.Create<TestRequestDTO>();

                //act
                var response = (HttpResult)service.Delete(requestContaingEntityToDelete);

                //assert
                Assert.Equal("hostapi/testEntity/" + requestContaingEntityToDelete.Ids, response.Headers["Location"]);   
            }
        }
    }
}