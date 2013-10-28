using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.JetNett.ServiceStackApi.Facts.Common;
using Api.JetNett.ServiceStackApi.Operations;
using Moq;
using Ploeh.AutoFixture;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
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
            mockTestRepository.Setup(i => i.GetById(It.IsAny<int>())).Returns(Fixture.Create<TestEntity>());
            mockTestRepository.Setup(i => i.Insert(It.IsAny<TestEntity>())).Returns(Fixture.Create<int>());
            mockTestRepository.Setup(i => i.UpdateEntity(It.IsAny<TestEntity>()));
            mockTestRepository.Setup(i => i.DeleteById(It.IsAny<int>()));

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
            public void ShouldFillEntityPropertyOfDTOWhenCalledWithNonDefaultId()
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
                Assert.NotNull(responseDTO.Entity);
            }

            [Fact]
            public void ShouldCallRepositorysGetByIdWhenRequestDTOIdIsNotZero()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object);

                //act 
                service.Get(new TestRequestDTO() { Id = Fixture.Create<int>() });

                //assert
                mockRepository.Verify(r => r.GetById(It.IsAny<int>()),Times.Once);
            }

            [Fact]
            public void ShouldCallReposGetAllWhenRequestDTOIdIsZero()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var service = new JetNettService<
                    TestRequestDTO,
                    TestResponseDTO,
                    TestEntity>
                    (null, mockRepository.Object);

                //act 
                service.Get(new TestRequestDTO() { Id = 0 });

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

                var mockRc = new Mock<IRequestContext>();
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

                var mockRc = new Mock<IRequestContext>();
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

                var mockRc = new Mock<IRequestContext>();
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

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdate = Fixture.Create<TestRequestDTO>();

                //act
                var response = (HttpResult)service.Put(entityToUpdate);

                //assert
                Assert.Equal("hostapi/testEntity/" + entityToUpdate.Id, response.Headers["Location"]);
            }

            [Fact]
            public void ShouldUpdateTheEntity()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdate = Fixture.Create<TestRequestDTO>();

                //act
                service.Put(entityToUpdate);

                //assert
                mockRepository.Verify(i => i.UpdateEntity(entityToUpdate.Entity), Times.Once);
            }

            [Fact]
            public void ShouldReturnANoContentHttpResponse()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var entityToUpdate = Fixture.Create<TestRequestDTO>();

                //act
                var response = (HttpResult)service.Put(entityToUpdate);

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

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var requestContaingEntityToDelete = Fixture.Create<TestRequestDTO>();

                //act
                service.Delete(requestContaingEntityToDelete);

                //assert
                mockRepository.Verify(i => i.DeleteById(requestContaingEntityToDelete.Id), Times.Once());
            }

            [Fact]
            public void ShouldReturnANoContentHttpResponse()
            {
                //arrange
                var mockRepository = CreateTestRepository();

                var mockRc = new Mock<IRequestContext>();
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

                var mockRc = new Mock<IRequestContext>();
                mockRc.SetupGet(r => r.AbsoluteUri).Returns("hostapi/testEntity");

                var service = new JetNettService<
                TestRequestDTO,
                TestResponseDTO,
                TestEntity>(null, mockRepository.Object, mockRc.Object);

                var requestContaingEntityToDelete = Fixture.Create<TestRequestDTO>();

                //act
                var response = (HttpResult)service.Delete(requestContaingEntityToDelete);

                //assert
                Assert.Equal("hostapi/testEntity/" + requestContaingEntityToDelete.Id, response.Headers["Location"]);   
            }
        }
    }
}