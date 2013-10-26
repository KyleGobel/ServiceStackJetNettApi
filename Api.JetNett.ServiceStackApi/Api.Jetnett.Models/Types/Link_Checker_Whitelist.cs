using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Link_Checker_Whitelist
    {
        public int ID { get; set; }
        public System.DateTime Date_Added { get; set; }
        public string URL { get; set; }
    }
}
