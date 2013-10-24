using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Us
    {
        public int ID { get; set; }
        public int End_User_ID { get; set; }
        public System.DateTime Date_Used { get; set; }
        public System.DateTime Time_Used { get; set; }
        public string Extra { get; set; }
    }
}
