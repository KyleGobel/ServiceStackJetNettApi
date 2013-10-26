using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Sub_License
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Password { get; set; }
        public string Target_URL { get; set; }
        public string Center_Graphic_URL { get; set; }
        public string Graphic_Overlay_URL { get; set; }
        public string Text_Overlay { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public Nullable<int> Font_Size { get; set; }
        public string Font_Color { get; set; }
        public string Text_Background_Color { get; set; }
        public Nullable<bool> Center_Graphic_Opens_New_Window { get; set; }
    }
}
