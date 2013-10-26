using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Community_ZipCodes
    {
        public int ID { get; set; }
        public Nullable<int> Page_ID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
    }
}
