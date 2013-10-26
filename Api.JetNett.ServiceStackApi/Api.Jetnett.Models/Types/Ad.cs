using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Ad
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link_Text { get; set; }
        public string Caption { get; set; }
        public string URL { get; set; }
        public string Caption_2 { get; set; }
        public string Headline { get; set; }
        public string Tags { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public int Client_ID { get; set; }
        public string Object_URL { get; set; }
        public int Ad_Group { get; set; }
        public int Object_Width { get; set; }
        public int Object_Height { get; set; }
        public string Extra { get; set; }
        public double View_Price { get; set; }
        public int Ad_Mode { get; set; }
        public int Ad_Limit { get; set; }
    }
}
