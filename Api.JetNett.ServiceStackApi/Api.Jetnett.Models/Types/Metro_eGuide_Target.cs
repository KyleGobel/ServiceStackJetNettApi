using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class Metro_eGuide_Target
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string URL { get; set; }
        public virtual Client Client { get; set; }
    }
}
