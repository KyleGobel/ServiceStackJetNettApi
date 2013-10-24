using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Email_Tracker
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Sender_Email { get; set; }
        public string Message { get; set; }
        public string City { get; set; }
        public string Subject { get; set; }
        public bool User_Registered { get; set; }
        public string User_Code { get; set; }
        public System.DateTime Date_Sent { get; set; }
    }
}
