using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class admin
    {
        public string admin_id { get; set; }
        public string admin_pass { get; set; }
        public Nullable<int> admin_level { get; set; }
        public string display_name { get; set; }
    }
}
