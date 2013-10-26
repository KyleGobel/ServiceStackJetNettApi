using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Schools_eGuide_End_Users
    {
        public int ID { get; set; }
        public Nullable<int> Side_Menu_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Schools_eGuide_Side_Menu Schools_eGuide_Side_Menu { get; set; }
    }
}
