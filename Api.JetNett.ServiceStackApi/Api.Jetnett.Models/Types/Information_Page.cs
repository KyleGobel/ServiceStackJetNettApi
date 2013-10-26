using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Information_Page
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
