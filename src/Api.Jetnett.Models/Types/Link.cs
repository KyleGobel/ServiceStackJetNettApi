using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Links")]
    public class Link
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Alias("Page_ID")]
        [ForeignKey(typeof(Page), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int PageId { get; set; }
        public int Position { get; set; }

        [Alias("Is_Link")]
        public bool IsLink { get; set; }

        public string Title { get; set; }

        [Alias("URL")]
        public string Url { get; set; }

        public string Target { get; set; }

        public override bool Equals(object obj)
        {
            var link = obj as Link;
            return link != null && this.Id.Equals(link.Id) && this.PageId.Equals(link.PageId);
        }
    }
}
