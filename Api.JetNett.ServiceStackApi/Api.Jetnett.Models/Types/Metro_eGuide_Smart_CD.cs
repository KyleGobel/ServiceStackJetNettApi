using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Metro_eGuide_Smart_CD
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Password { get; set; }
        public string Target_URL { get; set; }
    }
}
