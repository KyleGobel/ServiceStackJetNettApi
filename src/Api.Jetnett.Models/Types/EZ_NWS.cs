using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class EZ_NWS
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public int Section { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
    }
}
