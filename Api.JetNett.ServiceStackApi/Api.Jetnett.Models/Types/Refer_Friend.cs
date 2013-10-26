using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Refer_Friend
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Target_URL { get; set; }
        public string Client_Email_URL { get; set; }
        public string Thank_You_Email_URL { get; set; }
        public string Friend_Email_URL { get; set; }
        public string Email_Graphic_URL { get; set; }
    }
}
