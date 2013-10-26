using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Active_Jobs
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public System.DateTime Due_Date { get; set; }
        public string Status { get; set; }
        public string Filler { get; set; }
        public Nullable<bool> Complete { get; set; }
    }
}
