using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Community_ZipCodes")]
    public class CommunityZipcodes
    {
        public int Id { get; set; }

        [Alias("Page_ID")]
        public int? PageId { get; set; }

        public string Name { get; set; }

        public string Zipcode { get; set; }
    }
}
