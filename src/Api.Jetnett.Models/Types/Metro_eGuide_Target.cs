using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Metro_eGuide_Target
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string URL { get; set; }
        public virtual Client Client { get; set; }
    }
}
