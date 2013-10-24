using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Verifier
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Base_URL { get; set; }
        public string Target_URL { get; set; }
    }
}
