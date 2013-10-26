using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Contact_Page_Staff_Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email_Name { get; set; }
        public string Email_Link { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public string Text { get; set; }
        public string Photo_URL { get; set; }
    }
}
