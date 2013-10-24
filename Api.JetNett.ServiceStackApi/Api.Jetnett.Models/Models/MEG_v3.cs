using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class MEG_v3
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public int Button_Count { get; set; }
        public int Button_Link_Page_ID { get; set; }
        public int Button_Border_Thickness { get; set; }
        public string Button_Border_Color { get; set; }
        public string Button_Title_Font_Color { get; set; }
        public string Button_Title_Font_Family { get; set; }
        public string Button_Title_Font_Weight { get; set; }
        public string Button_Background_Color { get; set; }
        public string Search_Bar_Background_Color { get; set; }
        public string Top_Left_Graphic_URL { get; set; }
        public string Weather_Zipcode { get; set; }
        public string Index_URL { get; set; }
        public string Search_Folders { get; set; }
        public string Help_URL { get; set; }
        public string Custom_Google_Search { get; set; }
        public string Main_Title { get; set; }
        public string MEG_Graphic_URL { get; set; }
        public string Center_Graphic_URL { get; set; }
        public int Copyright_Font_Size { get; set; }
        public string Copyright_Font_Color { get; set; }
        public string Copyright_Font_Family { get; set; }
        public string Realtor_Graphic_URL { get; set; }
        public string Copyright_Text { get; set; }
        public string Top_Left_Graphic_Target { get; set; }
        public string Center_Graphic_Target { get; set; }
        public string Page_Background_Color { get; set; }
        public string Center_Graphic_Border_Color { get; set; }
        public int Center_Graphic_Border_Thickness { get; set; }
        public string Button_MouseOver_BG_Color { get; set; }
        public string Button_MouseOver_Border_Color { get; set; }
        public string Button_MouseOver_Font_Color { get; set; }
        public string Main_Title_Font_Family { get; set; }
        public int Main_Title_Font_Size { get; set; }
        public string Main_Title_Font_Color { get; set; }
        public string Company_Graphic_URL { get; set; }
        public string Home_Search_Text { get; set; }
        public string Home_Search_URL { get; set; }
        public Nullable<int> Mobile_Stack_ID { get; set; }
        public string SEOMetaKeys { get; set; }
        public string SEOMetaDesc { get; set; }
        public virtual Client Client { get; set; }
        public virtual Stack Stack { get; set; }
    }
}
