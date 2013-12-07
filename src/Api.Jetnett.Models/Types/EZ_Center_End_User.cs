using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class EZ_Center_End_User
    {
        public int ID { get; set; }
        public string Client_Code { get; set; }
        public string Name { get; set; }
        public string EU_Code { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Last_Logon { get; set; }
        public Nullable<int> Visits { get; set; }
        public string RedirectTo { get; set; }
        public Nullable<System.DateTime> Expires_On { get; set; }
        public Nullable<int> Zip_Code { get; set; }
        public Nullable<bool> Expiration_Notice_Sent { get; set; }
    }
}
