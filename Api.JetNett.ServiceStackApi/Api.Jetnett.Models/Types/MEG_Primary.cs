using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class MEG_Primary
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Photo_URL { get; set; }
        public string Button1_Text { get; set; }
        public string Button1_URL { get; set; }
        public string Button1_Target { get; set; }
        public string Button2_Text { get; set; }
        public string Button2_URL { get; set; }
        public string Button2_Target { get; set; }
        public string Button3_Text { get; set; }
        public string Button3_URL { get; set; }
        public string Button3_Target { get; set; }
        public string Button4_Text { get; set; }
        public string Button4_URL { get; set; }
        public string Button4_Target { get; set; }
    }
}
