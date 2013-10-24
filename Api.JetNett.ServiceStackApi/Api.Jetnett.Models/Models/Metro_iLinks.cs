using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Metro_iLinks
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string PageBGColor { get; set; }
        public string PageTextColor { get; set; }
        public string PageLinkColor { get; set; }
        public string HomeSearchText { get; set; }
        public string HomeSearchURL { get; set; }
        public string OriginationPage { get; set; }
        public string BackLinkTitle { get; set; }
        public string BackLinkURL { get; set; }
        public string BackLinkTarget { get; set; }
        public string DropDownPageIDs { get; set; }
        public string ClientLogoGraphicLocation { get; set; }
        public string ClientLogoLinkURL { get; set; }
        public string ClientLogoTargetWindow { get; set; }
        public string ClientLogoAltText { get; set; }
        public string ProductLogoGraphicLocation { get; set; }
        public string ProductLogoLinkURL { get; set; }
        public string ProductLogoTargetWindow { get; set; }
        public string ProductLogoAltText { get; set; }
        public string OriginationPageTarget { get; set; }
        public string SEOMetaKeys { get; set; }
        public string SEOMetaDesc { get; set; }
        public Nullable<int> FontSizePx { get; set; }
        public virtual Client Client { get; set; }
    }
}
