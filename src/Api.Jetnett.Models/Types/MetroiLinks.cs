using System;
using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Metro_iLinks")]
    public class MetroiLinks
    {
        [AutoIncrement]
        public int Id { get; set; }
        [Alias("Client_ID")]
        [ForeignKey(typeof(Client), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int ClientId { get; set; }

        public string PageBgColor { get; set; }
        public string PageTextColor { get; set; }
        public string PageLinkColor { get; set; }
        public string HomeSearchText { get; set; }
        public string HomeSearchUrl { get; set; }
        public string OriginationPage { get; set; }
        public string BackLinkTitle { get; set; }
        public string BackLinkUrl { get; set; }
        public string BackLinkTarget { get; set; }
        public string DropDownPageIds { get; set; }
        public string ClientLogoGraphicLocation { get; set; }
        public string ClientLogoLinkUrl { get; set; }
        public string ClientLogoTargetWindow { get; set; }
        public string ClientLogoAltText { get; set; }
        public string ProductLogoGraphicLocation { get; set; }
        public string ProductLogoLinkUrl { get; set; }
        public string ProductLogoTargetWindow { get; set; }
        public string ProductLogoAltText { get; set; }
        public string OriginationPageTarget { get; set; }
        public string SeoMetaKeys { get; set; }
        public string SeoMetaDesc { get; set; }
        public int ? FontSizePx { get; set; }

        public override bool Equals(object obj)
        {
            var ilink = obj as MetroiLinks;

            return ilink != null && ilink.Id.Equals(this.Id) && ilink.ClientId.Equals(this.ClientId);
        }
    }
}
