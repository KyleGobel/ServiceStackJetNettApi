using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class FavLink
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public bool Is_Link { get; set; }
        public string Target { get; set; }
        public int End_User_ID { get; set; }
        public string Display_Title { get; set; }
        public int Position { get; set; }
        public int ID { get; set; }
    }
}
