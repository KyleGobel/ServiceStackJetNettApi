using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Reported_Links
    {
        public int ID { get; set; }
        public Nullable<int> Link_ID { get; set; }
        public Nullable<int> Page_ID { get; set; }
        public Nullable<System.DateTime> Date_Reported { get; set; }
        public Nullable<System.DateTime> Date_Corrected { get; set; }
        public string Link_Title { get; set; }
        public string Page_Title { get; set; }
        public string New_Link_Title { get; set; }
        public string URL { get; set; }
        public string New_URL { get; set; }
        public Nullable<bool> Corrected { get; set; }
        public string Comment { get; set; }
        public string Filename { get; set; }
        public virtual Link Link { get; set; }
    }
}
