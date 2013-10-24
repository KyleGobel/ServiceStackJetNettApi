using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Schools_eGuide
    {
        public Schools_eGuide()
        {
            this.Schools_eGuide_Side_Menu = new List<Schools_eGuide_Side_Menu>();
        }

        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string State { get; set; }
        public string Lower_Graphic_URL { get; set; }
        public string Where_String { get; set; }
        public string Referer_URL { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Schools_eGuide_Side_Menu> Schools_eGuide_Side_Menu { get; set; }
    }
}
