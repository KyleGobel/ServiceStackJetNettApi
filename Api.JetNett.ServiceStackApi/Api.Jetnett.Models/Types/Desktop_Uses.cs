using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Desktop_Uses
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Date { get; set; }
        public int Client_ID { get; set; }
        public string Zipcode { get; set; }
    }
}
