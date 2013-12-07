using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Schools_eGuide_Tracker
    {
        public int ID { get; set; }
        public Nullable<int> Client_ID { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Visits { get; set; }
        public virtual Client Client { get; set; }
    }
}
