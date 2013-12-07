using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Available_Properties_Page
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> Link_Page_ID { get; set; }
        public Nullable<int> PropertyID1 { get; set; }
        public Nullable<int> PropertyID2 { get; set; }
        public Nullable<int> PropertyID3 { get; set; }
        public Nullable<int> PropertyID4 { get; set; }
        public Nullable<int> PropertyID5 { get; set; }
        public Nullable<int> PropertyID6 { get; set; }
        public Nullable<int> PropertyID7 { get; set; }
        public Nullable<int> PropertyID8 { get; set; }
        public Nullable<int> PropertyID9 { get; set; }
        public Nullable<int> PropertyID10 { get; set; }
        public string Image_List_Title { get; set; }
        public virtual Client Client { get; set; }
        public virtual Page Page { get; set; }
        public virtual Property_Listing Property_Listing { get; set; }
        public virtual Property_Listing Property_Listing1 { get; set; }
        public virtual Property_Listing Property_Listing2 { get; set; }
        public virtual Property_Listing Property_Listing3 { get; set; }
        public virtual Property_Listing Property_Listing4 { get; set; }
        public virtual Property_Listing Property_Listing5 { get; set; }
        public virtual Property_Listing Property_Listing6 { get; set; }
        public virtual Property_Listing Property_Listing7 { get; set; }
        public virtual Property_Listing Property_Listing8 { get; set; }
        public virtual Property_Listing Property_Listing9 { get; set; }
    }
}
