using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class MEG_Contact
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email_Address { get; set; }
    }
}
