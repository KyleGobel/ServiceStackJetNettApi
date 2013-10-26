using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Tracker
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public Nullable<int> Visits { get; set; }
        public Nullable<System.DateTime> Since { get; set; }
        public virtual Client Client { get; set; }
    }
}
