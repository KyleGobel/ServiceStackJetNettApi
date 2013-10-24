using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Customer_Messages
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public int End_User_ID { get; set; }
        public Nullable<bool> Client_Sent { get; set; }
        public Nullable<bool> In_Folder { get; set; }
        public Nullable<System.DateTime> Date_Sent { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public Nullable<bool> Is_Attachment { get; set; }
        public string Attachment_URL { get; set; }
        public string Save_As { get; set; }
        public Nullable<bool> Message_Read { get; set; }
    }
}
