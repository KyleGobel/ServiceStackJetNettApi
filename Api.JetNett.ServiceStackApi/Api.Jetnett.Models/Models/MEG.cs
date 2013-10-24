using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class MEG
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Password { get; set; }
        public string Notification_Email { get; set; }
        public string Client_Target_Page { get; set; }
        public Nullable<int> Ad_Group { get; set; }
        public string Update_Webpage { get; set; }
        public string Title { get; set; }
        public string Left_Graphic_Link { get; set; }
        public string Right_Graphic_Link { get; set; }
        public Nullable<int> Search_Folder_1 { get; set; }
        public Nullable<int> Search_Folder_2 { get; set; }
        public Nullable<int> Search_Folder_3 { get; set; }
        public string Active_Link_Color { get; set; }
        public Nullable<int> Abandon_Client_ID { get; set; }
        public string XML_URL { get; set; }
        public string Desktop_XML_URL { get; set; }
        public string Index_URL { get; set; }
        public string Custom_Google_Search { get; set; }
        public string Heading_1_Action { get; set; }
        public string Heading_2_Action { get; set; }
        public string Heading_3_Action { get; set; }
        public string Footer_1_Action { get; set; }
        public string Footer_2_Action { get; set; }
        public string Footer_3_Action { get; set; }
        public string Search_Folders { get; set; }
    }
}
