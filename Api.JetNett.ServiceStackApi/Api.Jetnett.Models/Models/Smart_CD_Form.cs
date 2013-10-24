using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Smart_CD_Form
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string smartName { get; set; }
        public string smartWebsite { get; set; }
        public string smartHomeSearch { get; set; }
        public string contactName { get; set; }
        public string contactAddress { get; set; }
        public string contactCity { get; set; }
        public string contactState { get; set; }
        public string contactZip { get; set; }
        public string contactDirect { get; set; }
        public string contactMobile { get; set; }
        public string contactOffice { get; set; }
        public string contactFax { get; set; }
        public string contactEmail { get; set; }
        public string Designations5 { get; set; }
        public string Designations4 { get; set; }
        public string Designations3 { get; set; }
        public string Designations2 { get; set; }
        public string Designations1 { get; set; }
        public string Filename { get; set; }
        public string otherInformation { get; set; }
        public Nullable<bool> threeButton { get; set; }
        public string smartBuyingHome { get; set; }
        public string smartSellingHome { get; set; }
        public string Background_Color { get; set; }
        public string Graphics_Location { get; set; }
        public string companyName { get; set; }
        public string contactMainColor { get; set; }
        public string contactHeadingColor { get; set; }
        public string contactButtonURL { get; set; }
        public string smartName2 { get; set; }
        public string smartPhone { get; set; }
        public virtual Client Client { get; set; }
    }
}
