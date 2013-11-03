using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Links")]
    public class Link
    {
        public int Id { get; set; }

        [Alias("Page_ID")]
        public int PageId { get; set; }
        public int Position { get; set; }

        [Alias("Is_Link")]
        public bool IsLink { get; set; }

        public string Title { get; set; }

        [Alias("URL")]
        public string Url { get; set; }

        public string Target { get; set; }
    }
}
