using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class menuLink
    {
        public int ID { get; set; }
        public int Folder_ID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Opens_New_Window { get; set; }
        public string Menu_URL { get; set; }
        public string URL { get; set; }
        public Nullable<int> Position { get; set; }
        public string Background_Bar_URL { get; set; }
    }
}
