using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Link_Viewer_Logs
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Username { get; set; }
        public int Folder_ID { get; set; }
        public int Page_ID { get; set; }
        public int Link_ID { get; set; }
        public string Event { get; set; }
    }
}
