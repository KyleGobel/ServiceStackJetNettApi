using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Suspended_Links
    {
        public int ID { get; set; }
        public int Link_ID { get; set; }
        public System.DateTime Date_Suspended { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
    }
}
