using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    public class AdGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ads { get; set; }

        [Alias("Viewport_Size")]
        public int ViewportSize { get; set; }

        public int Seed { get; set; }

        [Alias("Fallback_AdGroup")]
        public int? FallbackAdGroup { get; set; }
    }
}
