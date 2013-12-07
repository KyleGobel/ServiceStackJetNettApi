using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Send_To_Friend
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body_Text { get; set; }
        public string Body_URL { get; set; }
        public string Body_RegID { get; set; }
        public string Body_Signature { get; set; }
    }
}
