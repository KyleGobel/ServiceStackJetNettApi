using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Service_Requests
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Status_Message { get; set; }
        public Nullable<bool> Complete { get; set; }
        public string Name { get; set; }
        public string Problem_Title { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
