using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class Ads_Model
    {
        public Ads_Model()
        {
            this.Ad_Assignments = new List<Ad_Assignments>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Client_ID { get; set; }
        public System.DateTime Date_Created { get; set; }
        public int Ad_Height { get; set; }
        public string Html { get; set; }
        public string Border_Style { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Ad_Assignments> Ad_Assignments { get; set; }
        public virtual Client Client { get; set; }
    }
}
