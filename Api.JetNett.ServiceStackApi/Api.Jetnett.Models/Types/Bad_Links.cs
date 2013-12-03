using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Bad_Links")]
    public class BadLink
    {
        public int Id { get; set; }

        [Alias("Link_ID")]
        public int LinkId { get; set; }

        [Alias("Original_Page_ID")]
        public int OriginalPageId { get; set; }

        [Alias("Original_Position")]
        public int OriginalPosition { get; set; }

        [Alias("Is_Suspended")]
        public bool IsSuspended { get; set; }

        [Alias("Is_Elevated")]
        public bool IsElevated { get; set; }

        [Alias("Status_Code")]
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }

        [Alias("Screen_Shot_URL")]
        public string ScreenShotUrl { get; set; }

        [Alias("Date_Reported")]
        public System.DateTime DateReported { get; set; }
    }
}
