using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Page
    {
        public Page()
        {
            this.Ad_Page_Relationship = new List<Ad_Page_Relationship>();
            this.Available_Properties_Page = new List<Available_Properties_Page>();
            this.Bad_Links = new List<Bad_Links>();
            this.Contact_Page = new List<Contact_Page>();
            this.Links = new List<Link>();
        }

        public int ID { get; set; }
        public int Folder_ID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Auto_Ordering { get; set; }
        public string Footer_HTML { get; set; }
        public string MetaKeys { get; set; }
        public string MetaDesc { get; set; }
        public string Canonical_URL { get; set; }
        public string Extra_HTML { get; set; }
        public string Route { get; set; }
        public virtual ICollection<Ad_Page_Relationship> Ad_Page_Relationship { get; set; }
        public virtual ICollection<Available_Properties_Page> Available_Properties_Page { get; set; }
        public virtual ICollection<Bad_Links> Bad_Links { get; set; }
        public virtual ICollection<Contact_Page> Contact_Page { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
