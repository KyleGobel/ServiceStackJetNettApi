using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class ByEmailNew
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public Nullable<int> CALs { get; set; }
        public string File_Location { get; set; }
        public string Verification_URL { get; set; }
        public Nullable<bool> Use_MEG_Email { get; set; }
        public string MEG_Email { get; set; }
        public Nullable<bool> Email_Notification { get; set; }
    }
}
