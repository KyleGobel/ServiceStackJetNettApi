using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class salesPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Extension { get; set; }
        public string Street_Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Photo_URL { get; set; }
    }
}
