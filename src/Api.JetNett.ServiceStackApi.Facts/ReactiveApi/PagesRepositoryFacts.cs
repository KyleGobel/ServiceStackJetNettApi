using System.Linq;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using JetNettApiReactive;
using ServiceStack;
using Xunit;
using System.Reactive.Linq;


    //mostly integration tests, requires Testconfig.DevHostBaseUrl server up and running
    public class PagesRepositoryFacts : IUseFixture<TestDb>
    {
        #region Setup
        PagesRepository ReactiveRepo { get; set; }
        TestDb TestDatabase { get; set; }
        public PagesRepositoryFacts()
        {
            var serviceClient = new JsonServiceClient(TestConfig.DevHostBaseUrl);
            ReactiveRepo = new PagesRepository(serviceClient);
        }
        public void SetFixture(TestDb data)
        {
            TestDatabase = data;
        }
#endregion     

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void GetAllPagesReturnsAllPages()
        {
            var result = await ReactiveRepo.GetAll();

            Assert.NotNull(result);
            Assert.Equal(TestDatabase.SeedPages, result);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void GetPagesByFolderIdReturnsOnlyPagesWithSpecifiedFolderId()
        {
            var folderToQuery = TestDatabase.SeedFolders[0];
            var result = await ReactiveRepo.GetByFolderId(folderToQuery.Id);

            Assert.NotNull(result);
            Assert.Equal(TestDatabase.SeedPages.Where(page => page.FolderId == folderToQuery.Id), result);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void GetPagesByIdsReturnsOnlyThosePages()
        {
            var evenPages = TestDatabase.SeedPages.Where(x => x.Id%2 == 0).Take(3).ToList();
            var result = await ReactiveRepo.GetByIds(evenPages[0].Id, evenPages[1].Id, evenPages[2].Id);
            Assert.Equal(evenPages, result);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void GetPageByIdReturnsCorrectPage()
        {
            var pageToGet = TestDatabase.SeedPages[0];
            var result = await ReactiveRepo.GetById(pageToGet.Id);

            Assert.Equal(pageToGet, result);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void AddPageShouldAddPage()
        {
            var pageToAdd = new Page {FolderId = TestDatabase.SeedFolders[0].Id, Title = "Test Page Insert"};

            var result = await ReactiveRepo.Add(pageToAdd);
            pageToAdd.Id = result;

            Assert.True(result > 0);
            Assert.Equal(pageToAdd, await ReactiveRepo.GetById(result));

            ReactiveRepo.Delete(pageToAdd.Id);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void DeletePage_ShouldDeleteAPage()
        {
            var pageId = TestDatabase.SeedPages[0].Id;
            ReactiveRepo.Delete(pageId);

            var deletedPage = await ReactiveRepo.GetById(pageId);
            Assert.Null(deletedPage);
        }

        [Fact]
        [Trait("ReactiveRepo", "PagesRepository")]
        public async void GetPagesPathsShouldReplaceTitlesWithPaths()
        {
            var page = TestDatabase.SeedPages[0];
            var expectedOutput = TestDatabase.SeedFolders.Single(x => x.Id == page.FolderId).Name + " > " + page.Title;
            var result = await ReactiveRepo.GetPagePath(page.Id);

            Assert.Equal(expectedOutput, result.Single().Title);
        }

    }