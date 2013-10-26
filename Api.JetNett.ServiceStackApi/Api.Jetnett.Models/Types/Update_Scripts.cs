using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Update_Scripts
    {
        public int Client_ID { get; set; }
        public string Location { get; set; }
        public int Version { get; set; }
    }
}
