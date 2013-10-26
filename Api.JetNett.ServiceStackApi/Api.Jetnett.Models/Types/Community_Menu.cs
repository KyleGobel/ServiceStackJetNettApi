using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Community_Menu
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Back_URL { get; set; }
        public Nullable<int> Folder_ID { get; set; }
        public string Link_1 { get; set; }
        public string Link_1_URL { get; set; }
        public string Link_2 { get; set; }
        public string Link_2_URL { get; set; }
        public string Link_3 { get; set; }
        public string Link_3_URL { get; set; }
        public string Link_4 { get; set; }
        public string Link_4_URL { get; set; }
        public string Link_5 { get; set; }
        public string Link_5_URL { get; set; }
        public string Link_6 { get; set; }
        public string Link_6_URL { get; set; }
        public string Link_7 { get; set; }
        public string Link_7_URL { get; set; }
        public string Back_Button_Graphic { get; set; }
        public string Back_Button_URL { get; set; }
        public string Page_IDs { get; set; }
        public string Color { get; set; }
        public string Text_Color { get; set; }
    }
}
