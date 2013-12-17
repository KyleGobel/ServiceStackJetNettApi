using System;
using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using Api.JetNett.ServiceStackApi.Facts.ReactiveApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using ServiceStack;
using Xunit;

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
            public void ReturnsAllPages_GivenEmptyListPagesRequest()
            {
                var results = PagesService.Get(new ListPagesRequest());

                Assert.NotNull(results);
                Assert.Equal(TestDatabase.SeedPages, results);
            }

            [Fact]
            [Trait("ServiceTest", "Page")]
            [Trait("Verb", "GET")]
            public void ReturnsAllPagesInAFolder_WhenFolderIdIsNonDefault()
            {

                var folderId = TestDatabase.SeedFolders[0].Id;
                var results = PagesService.Get(new ListPagesRequest {FolderId = folderId});

                Assert.NotNull(results);
                Assert.Equal(TestDatabase.SeedPages.Where(x => x.FolderId == folderId), results);
            }

            [Fact]
            [Trait("ServiceTest", "Page")]
            [Trait("Verb", "GET")]
            public void ReturnsAllPagesSpecified_GivenAnArrayOfIds()
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
            public void ReturnsAPage()
            {
                var pageToQuery = TestDatabase.SeedPages[0];
                var result = PagesService.Get(new PageRequest(pageToQuery.Id));

                Assert.Equal(pageToQuery, result);
            }
        }
    }

    public class ThePutVerb : PageServiceFacts
    {
        [Fact]
        [Trait("ServiceTest", "Page")]
        [Trait("Verb", "PUT")]
        public void UpdatesAPage()
        {
            var page = TestDatabase.SeedPages[0];
            var now = DateTime.Now;
            var pageTitle = "Brand new at {0}".FormatWith(now.ToString());
            page.Title = pageTitle;

            PagesService.Put(new UpdatePageRequest(page.Id, page));

            Assert.Equal(pageTitle, PagesService.Get(new PageRequest(page.Id)).Title);
        }
    }

    public class TheDeleteVerb : PageServiceFacts
    {
        [Fact]
        [Trait("ServiceTest", "Page")]
        [Trait("Verb", "DELETE")]
        public void DeletesAPage()
        {
            int id = PagesService.Post(new InsertPageRequest(new Page {Title = " new page", FolderId = TestDatabase.SeedFolders[0].Id}));

            PagesService.Delete(new DeletePageRequest(id));

            Assert.Null(PagesService.Get(new PageRequest(id)));
        }
    }
    public class ThePostVerb : PageServiceFacts, IDisposable
    {
        protected int InsertedPageId { get; set; }
        [Fact]
        [Trait("ServiceTest", "Page")]
        [Trait ("Verb", "POST")]
        public void InsertsAPage()
        {
            var pageToInsert = new Page {FolderId = 1, Title = "Test Page To Insert"};

            InsertedPageId = PagesService.Post(new InsertPageRequest(pageToInsert));
            pageToInsert.Id = InsertedPageId;

            Assert.NotEqual(InsertedPageId, 0);

            Assert.Equal(pageToInsert, PagesService.Get(new PageRequest(InsertedPageId)));
        }

        public void Dispose()
        {
            PagesService.Delete(new DeletePageRequest(InsertedPageId));
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
    public void ReturnsPagesWithPathInfoAsTitles()
    {
        var page = TestDatabase.SeedPages[0];
        var result = PagePathInfoService.Get(new PagesWithPathsAsTitles(page.Id));

        var parentFolder = TestDatabase.SeedFolders.Single(x => x.Id == page.FolderId);

        Assert.Equal(parentFolder.Name + " > " + page.Title, result.Single().Title);
    }
}