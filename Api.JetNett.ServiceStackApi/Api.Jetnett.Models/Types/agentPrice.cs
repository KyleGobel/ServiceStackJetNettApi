using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class agentPrice
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
