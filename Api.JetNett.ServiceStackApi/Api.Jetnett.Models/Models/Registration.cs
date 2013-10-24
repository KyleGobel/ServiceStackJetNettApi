using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Registration
    {
        public int ID { get; set; }
        public string Registration_ID { get; set; }
        public Nullable<int> Used { get; set; }
    }
}
