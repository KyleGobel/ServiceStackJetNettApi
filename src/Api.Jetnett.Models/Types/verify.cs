using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class verify
    {
        public int client_id { get; set; }
        public string client_url { get; set; }
        public string target_page { get; set; }
        public string client_name { get; set; }
    }
}
