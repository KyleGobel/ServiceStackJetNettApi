using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Property_Listing
    {
        public Property_Listing()
        {
            this.Available_Properties_Page = new List<Available_Properties_Page>();
            this.Available_Properties_Page1 = new List<Available_Properties_Page>();
            this.Available_Properties_Page2 = new List<Available_Properties_Page>();
            this.Available_Properties_Page3 = new List<Available_Properties_Page>();
            this.Available_Properties_Page4 = new List<Available_Properties_Page>();
            this.Available_Properties_Page5 = new List<Available_Properties_Page>();
            this.Available_Properties_Page6 = new List<Available_Properties_Page>();
            this.Available_Properties_Page7 = new List<Available_Properties_Page>();
            this.Available_Properties_Page8 = new List<Available_Properties_Page>();
            this.Available_Properties_Page9 = new List<Available_Properties_Page>();
        }

        public int ID { get; set; }
        public string Property_Address { get; set; }
        public string Listing_URL { get; set; }
        public string Property_Info { get; set; }
        public string Map_Title { get; set; }
        public string Map_URL { get; set; }
        public string Photo_URL { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page1 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page2 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page3 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page4 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page5 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page6 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page7 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page8 { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page9 { get; set; }
    }
}
