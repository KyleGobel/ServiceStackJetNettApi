﻿using System;
using System.Linq;
using Api.JetNett.Models.Mixins;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using Api.JetNett.ServiceStackApi;
using Api.JetNett.ServiceStackApi.Facts.Setup;
using ServiceStack.Logging;
using ServiceStack.Support;
using Xunit;


    public class FolderServiceFacts 
    {
        protected Db Database { get; set; }
        protected FolderService FolderService { get; set; }

        public FolderServiceFacts()
        {
            Database = new Db();
            Database.SetupDatabase();
            FolderService = new FolderService(Database.ConnectionFactory);
        }
        public class TheGetMethod 
        {
            public class ListFoldersRequestOverload : FolderServiceFacts
            {
                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Folder")]
                public void ReturnsAllFolders_WhenCalledWithEmptyListRequest()
                {
                    var results = FolderService.Get(new ListFoldersRequest());
                    Assert.Equal(Database.SeedFolders, results);
                }

                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Folder")]
                public void ReturnsFolders_WhenCalledWithListOfIds()
                {
                    var folder = Database.SeedFolders[0];
                    var results = FolderService.Get(new ListFoldersRequest() {Ids = folder.Id.ToEnumerable().ToArray()});

                    Assert.Equal(1, results.Count);
                    Assert.Equal(folder, results[0]);
                }

                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Folder")]
                public void ReturnsListOfChildFolders_WhenCalledWithParentFolderId()
                {
                    var folder = Database.SeedFolders[0];
                    var results = FolderService.Get(new ListFoldersRequest() {ParentId = folder.Id});

                    Assert.Equal(results, Database.SeedFolders.Where(x => x.ParentFolderId == folder.Id));
                }
            }

            public class GetFoldersRequestOverload : FolderServiceFacts
            {
                [Fact]
                [Trait("Verb", "GET")]
                [Trait("ServiceTest", "Folder")]
                public void ReturnsFolderWithIdGivenToRequest()
                {
                    var result = FolderService.Get(new GetFolderRequest(Database.SeedFolders[0].Id));

                    Assert.Equal(Database.SeedFolders[0], result);
                }
            }
        }

        public class ThePutMethod : FolderServiceFacts
        {
            [Fact]
            [Trait("Verb", "PUT")]
            [Trait("ServiceTest", "Folder")]
            public void UpdatesAFolder()
            {
                const string newName = "An updated name";
                var folder = Database.SeedFolders[0];
                FolderService.Put(new UpdateFolderRequest(new Folder() { Id = folder.Id, Name=newName}));


                Assert.Equal(newName, FolderService.Get(new GetFolderRequest(folder.Id)).Name);
            }
        }

        public class ThePostMethod : FolderServiceFacts, IDisposable
        {
            protected int InsertedId { get; set; }
            [Fact]
            [Trait("Verb", "POST")]
            [Trait("ServiceTest", "Folder")]
            public void InsertsAFolder()
            {
                var newFolder = new Folder {Name = "A new Folder", ParentFolderId = Database.SeedFolders[1].Id};

                InsertedId = (int)FolderService.Post(new InsertFolderRequest(newFolder));

                newFolder.Id = InsertedId;


                var folder = FolderService.Get(new GetFolderRequest(InsertedId));

                Assert.Equal(InsertedId, folder.Id);
                Assert.Equal("A new Folder", folder.Name);
                Assert.Equal(Database.SeedFolders[1].Id, folder.ParentFolderId);
            }

            public void Dispose()
            {
                FolderService.Delete(new DeleteFolderRequest(InsertedId));
            }
        }

        public class TheDeleteMethod : FolderServiceFacts
        {
            [Fact]
            [Trait("Verb", "DELETE")]
            [Trait("ServiceTest", "Folder")]
            public void DeletesAFolder()
            {
                var testFolderForDeletetionId = (int) FolderService.Post(new InsertFolderRequest(new Folder() {Name="DeleteMe"}));
                FolderService.Delete(new DeleteFolderRequest(testFolderForDeletetionId));

                var folder = FolderService.Get(new GetFolderRequest(testFolderForDeletetionId));

                Assert.Null(folder);
            }
        }

    }
