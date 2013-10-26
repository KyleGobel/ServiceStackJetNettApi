using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class Ad_Assignments
    {
        public int ID { get; set; }
        public Nullable<int> Ad_ID { get; set; }
        public int Ad_Group { get; set; }
        public int Client_ID { get; set; }
        public string Name { get; set; }
        public int Height_Limitation { get; set; }
        public double View_Price { get; set; }
        public int Ad_Mode { get; set; }
        public int Ad_Limit { get; set; }
        public virtual Ad_Assignments Ad_Assignments1 { get; set; }
        public virtual Ad_Assignments Ad_Assignments2 { get; set; }
        public virtual AdGroup AdGroup { get; set; }
        public virtual Ads_Model Ads_Model { get; set; }
        public virtual Client Client { get; set; }
    }
}
