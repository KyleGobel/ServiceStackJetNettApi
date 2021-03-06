using System;
using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Models
{
    public partial class Smart_CD
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Password { get; set; }
        public string Target_URL { get; set; }
        public virtual Client Client { get; set; }
    }
}
