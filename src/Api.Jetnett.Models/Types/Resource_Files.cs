using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Resource_Files
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string MD5 { get; set; }
    }
}
