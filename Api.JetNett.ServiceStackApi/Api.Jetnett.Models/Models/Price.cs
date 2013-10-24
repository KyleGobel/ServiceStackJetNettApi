using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Price
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price1 { get; set; }
    }
}
