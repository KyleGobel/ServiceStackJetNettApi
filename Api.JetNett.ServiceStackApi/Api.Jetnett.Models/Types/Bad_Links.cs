using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Bad_Links
    {
        public int ID { get; set; }
        public int Link_ID { get; set; }
        public int Original_Page_ID { get; set; }
        public int Original_Position { get; set; }
        public bool Is_Suspended { get; set; }
        public bool Is_Elevated { get; set; }
        public int Status_Code { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }
        public string Screen_Shot_URL { get; set; }
        public System.DateTime Date_Reported { get; set; }
        public virtual Page Page { get; set; }
        public virtual Link Link { get; set; }
    }
}
