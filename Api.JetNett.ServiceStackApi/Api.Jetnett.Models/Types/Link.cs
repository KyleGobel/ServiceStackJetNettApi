using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Link
    {
        public Link()
        {
            this.Bad_Links = new List<Bad_Links>();
            this.Reported_Links = new List<Reported_Links>();
        }

        public int ID { get; set; }
        public int Page_ID { get; set; }
        public int Position { get; set; }
        public bool Is_Link { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Target { get; set; }
        public virtual ICollection<Bad_Links> Bad_Links { get; set; }
        public virtual Page Page { get; set; }
        public virtual ICollection<Reported_Links> Reported_Links { get; set; }
    }
}
