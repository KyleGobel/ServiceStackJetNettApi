using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Ad_View_Tracker
    {
        public int ID { get; set; }
        public int Ad_ID { get; set; }
        public int Age_Group { get; set; }
        public int Zipcode { get; set; }
        public bool Is_Male { get; set; }
        public int Client_ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Extra { get; set; }
        public int Page_ID { get; set; }
    }
}
