using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class Ad_Page_Relationship
    {
        public int ID { get; set; }
        public Nullable<int> Page_ID { get; set; }
        public Nullable<int> Ad_Group { get; set; }
        public string Broker_Code { get; set; }
        public bool Use_Broker_Code { get; set; }
        public Nullable<int> Client_ID { get; set; }
        public virtual AdGroup AdGroup { get; set; }
        public virtual Client Client { get; set; }
        public virtual Page Page { get; set; }
    }
}
