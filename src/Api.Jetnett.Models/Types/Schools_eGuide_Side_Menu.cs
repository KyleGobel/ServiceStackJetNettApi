using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Schools_eGuide_Side_Menu
    {
        public Schools_eGuide_Side_Menu()
        {
            this.Schools_eGuide_End_Users = new List<Schools_eGuide_End_Users>();
        }

        public int ID { get; set; }
        public int Schools_eGuide_ID { get; set; }
        public string Agent_Graphic_URL { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public string Home_Search_URL { get; set; }
        public string Website_URL { get; set; }
        public string CSS_URL { get; set; }
        public string Top_Graphic_URL { get; set; }
        public virtual Schools_eGuide Schools_eGuide { get; set; }
        public virtual ICollection<Schools_eGuide_End_Users> Schools_eGuide_End_Users { get; set; }
    }
}
