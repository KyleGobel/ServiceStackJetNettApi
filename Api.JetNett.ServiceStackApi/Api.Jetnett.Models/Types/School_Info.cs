using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class School_Info
    {
        public int ID { get; set; }
        public int Page_ID { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string School_Name { get; set; }
        public string School_Type { get; set; }
    }
}
