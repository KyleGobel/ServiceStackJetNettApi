using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class EZ_TTD
    {
        public Nullable<int> Client_ID { get; set; }
        public Nullable<bool> Main_Menu { get; set; }
        public Nullable<int> Section { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public int ID { get; set; }
        public string Graphic_URL { get; set; }
    }
}
