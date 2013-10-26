using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Folder_Fav
    {
        public int ID { get; set; }
        public Nullable<int> Folder_ID { get; set; }
        public Nullable<int> Page_ID { get; set; }
    }
}
