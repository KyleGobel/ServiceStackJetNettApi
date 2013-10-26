using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Metro_eGuide_By_Email
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Product_Name { get; set; }
        public Nullable<int> EXE { get; set; }
        public Nullable<int> Number_Of_Cal { get; set; }
        public string File_Location { get; set; }
        public string File_Download { get; set; }
        public Nullable<int> Sales_Agent { get; set; }
        public string Client_Specific_URL { get; set; }
        public string Side_Graphic_URL { get; set; }
        public string Verify_URL { get; set; }
        public Nullable<bool> Use_User_Email { get; set; }
        public string MEG_Email { get; set; }
        public string Area_Served { get; set; }
        public Nullable<bool> Email_Notification { get; set; }
    }
}
