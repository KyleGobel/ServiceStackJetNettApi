using System;
using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi.Facts.ReactiveApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using Xunit;

namespace Api.JetNett.ServiceStackApi.Facts.ServiceTests
{
    /// <summary>
    /// Integration Tests against a Test Database
    /// </summary>
    public class PageServiceFacts : IUseFixture<TestDb>
    {
        #region Setup
        protected PagesService PagesService { get; set; }
        protected TestDb TestDatabase { get; private set; }
        public void SetFixture(TestDb data)
        {
            TestDatabase = data;

            PagesService = new PagesService(TestDatabase.ConnectionFactory);
        }
        #endregion

        public class TheGetVerb : PageServiceFacts
        {
            public class TheListPagesOverload : TheGetVerb
            {
                [Fact]
                [Trait("ServiceTest", "Page")]
                [Trait("Verb", "GET")]
                public void ShouldGetAllPagesWhenPassedEmptyRequestObject()
                {
                    var results = PagesService.Get(new ListPagesRequest());

                    Assert.NotNull(results);
                    Assert.Equal(TestDatabase.SeedPages, results);
                }

                [Fact]
                [Trait("ServiceTest", "Page")]
                [Trait("Verb", "GET")]
                public void PagesByFolderId()
                {

                    var folderId = TestDatabase.SeedFolders[0].Id;
                    var results = PagesService.Get(new ListPagesRequest {FolderId = folderId});

                    Assert.NotNull(results);
                    Assert.Equal(TestDatabase.SeedPages.Where(x => x.FolderId == folderId), results);
                }

                [Fact]
                [Trait("ServiceTest", "Page")]
                [Trait("Verb", "GET")]
                public void PagesByIds()
                {
                    var oddIdPages = TestDatabase.SeedPages.Where(x => x.Id%2 == 1).ToList();

                    var results = PagesService.Get(new ListPagesRequest {Ids = oddIdPages.Select(x => x.Id).ToArray()});

                    Assert.NotNull(results);
                    Assert.Equal(oddIdPages, results);
                }
            }

            public class ThePageRequestOverload : TheGetVerb
            {
                [Fact]
                [Trait("ServiceTest", "Page")]
                [Trait("Verb", "GET")]
                public void ShouldReturnASinglePage()
                {
                    var pageToQuery = TestDatabase.SeedPages[0];
                    var result = PagesService.Get(new PageRequest(pageToQuery.Id));

                    Assert.Equal(pageToQuery, result);
                }
            }
        }

        public class ThePostVerb : PageServiceFacts, IDisposable
        {
            protected int InsertedPageId { get; set; }
            [Fact]
            [Trait("ServiceTest", "Page")]
            [Trait ("Verb", "POST")]
            public void ShouldInsertAPage()
            {
                var pageToInsert = new Page {FolderId = 1, Title = "Test Page To Insert"};

                InsertedPageId = PagesService.Post(new InsertPageRequest(pageToInsert));
                pageToInsert.Id = InsertedPageId;

                Assert.NotEqual(InsertedPageId, 0);

                Assert.Equal(pageToInsert, PagesService.Get(new PageRequest(InsertedPageId)));
            }

            public void Dispose()
            {
                //delete the inserted page Id
            }
        }
    }

    public class PagePathInfoServiceFacts : IUseFixture<TestDb>
    {
        #region Setup
        protected PagePathInfoService PagePathInfoService { get; set; }
        protected TestDb TestDatabase { get; private set; }
        public void SetFixture(TestDb data)
        {
            TestDatabase = data;

            PagePathInfoService = new PagePathInfoService(TestDatabase.ConnectionFactory);
        }
        #endregion

        [Fact]
        [Trait("ServiceTest", "PagePathInfo")]
        [Trait("Verb", "GET")]
        public void ShouldReplaceTitlesWithPaths()
        {
            var page = TestDatabase.SeedPages[0];
            var result = PagePathInfoService.Get(new PagesWithPathsAsTitles(page.Id));

            var parentFolder = TestDatabase.SeedFolders.Single(x => x.Id == page.FolderId);

            Assert.Equal(parentFolder.Name + " > " + page.Title, result.Single().Title);
        }
    }
}