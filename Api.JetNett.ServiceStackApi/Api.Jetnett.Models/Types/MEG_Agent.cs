using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class MEG_Agent
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
        public string PhotoURL { get; set; }
        public string ContactURL { get; set; }
        public virtual Client Client { get; set; }
    }
}
