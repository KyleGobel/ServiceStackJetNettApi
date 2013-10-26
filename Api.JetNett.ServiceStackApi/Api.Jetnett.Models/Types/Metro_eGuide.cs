using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Metro_eGuide
    {
        public int Client_ID { get; set; }
        public string Lower_Graphic_URL { get; set; }
        public string Home_Search_Title { get; set; }
        public string Home_Search_URL { get; set; }
        public virtual Client Client { get; set; }
    }
}
