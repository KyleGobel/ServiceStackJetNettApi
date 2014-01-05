using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Api.JetNett.Models.Operations;
using Api.JetNett.Models.Types;
using ServiceStack;

namespace JetNettApiReactive
{
    public class FolderRepository : BaseReactiveRepository<Folder>
    {
        public FolderRepository(JsonServiceClient client, int timeoutInSeconds = 5) : base(client, timeoutInSeconds)
        { }

        public override IObservable<List<Folder>> GetAll()
        {
            return JsonClient.GetAsync(new ListFoldersRequest()).ToObservable().Timeout(Timeout);
        }

        public override void Delete(int id)
        {
            JsonClient.Delete(new DeleteFolderRequest(id));
        }

        public override void Update(Folder entity)
        {
            JsonClient.Put(new UpdateFolderRequest(entity));
        }

        public override IObservable<Folder> GetById(int id)
        {
            return JsonClient.GetAsync(new GetFolderRequest(id)).ToObservable().Timeout(Timeout);
        }

        public override IObservable<List<Folder>> GetByIds(params int[] ids)
        {
            return JsonClient.GetAsync(new ListFoldersRequest() {Ids = ids}).ToObservable().Timeout(Timeout);
        }

        public IObservable<List<Folder>> GetChildFolders(int parentFolderId)
        {
            return
                JsonClient.GetAsync(new ListFoldersRequest {ParentId = parentFolderId}).ToObservable().Timeout(Timeout);
        }
    }
}