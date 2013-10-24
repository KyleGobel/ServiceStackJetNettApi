using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class AdGroup
    {
        public AdGroup()
        {
            this.Ad_Assignments = new List<Ad_Assignments>();
            this.Ad_Page_Relationship = new List<Ad_Page_Relationship>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Ads { get; set; }
        public int Viewport_Size { get; set; }
        public int Seed { get; set; }
        public Nullable<int> Fallback_AdGroup { get; set; }
        public virtual ICollection<Ad_Assignments> Ad_Assignments { get; set; }
        public virtual ICollection<Ad_Page_Relationship> Ad_Page_Relationship { get; set; }
    }
}
