using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Alias("Parent_Folder_ID")]
        public int? ParentFolderId { get; set; }
    }
}
