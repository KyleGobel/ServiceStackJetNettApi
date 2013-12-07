using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class MEG_SubLicense
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Button1_Text { get; set; }
        public string Button1_URL { get; set; }
        public string Button1_Target { get; set; }
        public string Button2_Text { get; set; }
        public string Button2_URL { get; set; }
        public string Button2_Target { get; set; }
        public string Button3_Text { get; set; }
        public string Button3_URL { get; set; }
        public string Button3_Target { get; set; }
    }
}
