using System;
using System.Linq;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using ServiceStack;
using Xunit;

/// <summary>
/// Integration Tests against a Test Database
/// </summary>
public class PageServiceFacts 
{
    #region Setup
    protected PagesService PagesService { get; set; }
    protected Db Database { get; private set; }

    public PageServiceFacts()
    {
        Database = new Db();
        Database.SetupDatabase();
        PagesService = new PagesService(Database.ConnectionFactory);
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
                Assert.Equal(Database.SeedPages, results);
            }

            [Fact]
            [Trait("ServiceTest", "Page")]
            [Trait("Verb", "GET")]
            public void ReturnsAllPagesInAFolder_WhenFolderIdIsNonDefault()
            {

                var folderId = Database.SeedFolders[0].Id;
                var results = PagesService.Get(new ListPagesRequest {FolderId = folderId});

                Assert.NotNull(results);
                Assert.Equal(Database.SeedPages.Where(x => x.FolderId == folderId), results);
            }

            [Fact]
            [Trait("ServiceTest", "Page")]
            [Trait("Verb", "GET")]
            public void ReturnsAllPagesSpecified_GivenAnArrayOfIds()
            {
                var oddIdPages = Database.SeedPages.Where(x => x.Id%2 == 1).ToList();

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
                var pageToQuery = Database.SeedPages[0];
                var result = PagesService.Get(new GetPageRequest(pageToQuery.Id));

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
            var page = Database.SeedPages[0];
            var now = DateTime.Now;
            var pageTitle = "Brand new at {0}".FormatWith(now.ToString());
            page.Title = pageTitle;

            PagesService.Put(new UpdatePageRequest(page.Id, page));

            Assert.Equal(pageTitle, PagesService.Get(new GetPageRequest(page.Id)).Title);
        }
    }

    public class TheDeleteVerb : PageServiceFacts
    {
        [Fact]
        [Trait("ServiceTest", "Page")]
        [Trait("Verb", "DELETE")]
        public void DeletesAPage()
        {
            var id = (int)PagesService.Post(new InsertPageRequest(new Page {Title = " new page", FolderId = Database.SeedFolders[0].Id}));

            PagesService.Delete(new DeletePageRequest(id));

            Assert.Null(PagesService.Get(new GetPageRequest(id)));
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

            InsertedPageId = (int)PagesService.Post(new InsertPageRequest(pageToInsert));
            pageToInsert.Id = InsertedPageId;

            Assert.NotEqual(InsertedPageId, 0);

            Assert.Equal(pageToInsert, PagesService.Get(new GetPageRequest(InsertedPageId)));
        }

        public void Dispose()
        {
            PagesService.Delete(new DeletePageRequest(InsertedPageId));
        }
    }
}

public class PagePathInfoServiceFacts 
{
    #region Setup
    protected PagePathInfoService PagePathInfoService { get; set; }
    protected Db Database { get; private set; }
    public PagePathInfoServiceFacts()
    {
        Database = new Db();
        Database.SetupDatabase();
        PagePathInfoService = new PagePathInfoService(Database.ConnectionFactory);
    }
    #endregion

    [Fact]
    [Trait("ServiceTest", "PagePathInfo")]
    [Trait("Verb", "GET")]
    public void ReturnsPagesWithPathInfoAsTitles()
    {
        var page = Database.SeedPages[0];
        var result = PagePathInfoService.Get(new PagesWithPathsAsTitles(page.Id));

        var parentFolder = Database.SeedFolders.Single(x => x.Id == page.FolderId);

        Assert.Equal(parentFolder.Name + " > " + page.Title, result.Single().Title);
    }
}