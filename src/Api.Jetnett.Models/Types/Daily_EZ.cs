using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Daily_EZ
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Search_Bar_Color { get; set; }
        public string Main_Title_Font_Color { get; set; }
        public int Main_Title_Font_Size { get; set; }
        public string Main_Title_Font_Family { get; set; }
        public string Main_Menu_Font_Color { get; set; }
        public int Main_Menu_Font_Size { get; set; }
        public string Main_Menu_Font_Family { get; set; }
        public string Top_Left_Image_URL { get; set; }
        public string Top_Right_Image_URL { get; set; }
        public string Bar_Image_URL { get; set; }
        public string Left_Middle_Display_Area_Html { get; set; }
        public int Link_Page_ID_1 { get; set; }
        public int Link_Page_ID_2 { get; set; }
        public string User_Friendly_URL { get; set; }
        public int Left_Index_ID { get; set; }
        public string Main_Title { get; set; }
        public string Top_Left_Image_Href { get; set; }
        public string Top_Right_Image_Href { get; set; }
        public int Directory_ID { get; set; }
        public string Custom_Google_Search_Key { get; set; }
        public string Search_Folders { get; set; }
        public bool Ad_Rotator_Enabled { get; set; }
        public int Ad_Seed { get; set; }
        public string Breaking_News_RSS_Feed { get; set; }
        public int Breaking_News_ID { get; set; }
        public string Sitemap_URL { get; set; }
        public string Breaking_News_Title { get; set; }
        public string Analytics_Code { get; set; }
        public string Sponsor_Title { get; set; }
        public int Default_Left_Stack { get; set; }
        public int Default_Right_Stack { get; set; }
        public string Main_Page_SEO_Text { get; set; }
        public string Search_Ad_Groups { get; set; }
        public string Top_Left_Image_ALT { get; set; }
        public string Top_Right_Image_ALT { get; set; }
        public Nullable<int> Mobile_Stack_ID { get; set; }
        public Nullable<int> Default_Middle_Stack { get; set; }
        public virtual Stack Stack { get; set; }
    }
}
