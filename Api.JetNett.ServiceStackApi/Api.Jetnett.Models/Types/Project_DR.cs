using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Project_DR
    {
        public int Client_ID { get; set; }
        public int ID { get; set; }
        public string Client_Code { get; set; }
        public string Redirect_To { get; set; }
    }
}
