using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Jetnett_Messages
    {
        public int ID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public System.DateTime Date { get; set; }
        public string Message { get; set; }
        public Nullable<bool> Read { get; set; }
        public string Subject { get; set; }
        public Nullable<bool> Attachment { get; set; }
        public string Attachment_URL { get; set; }
        public string SaveAs { get; set; }
    }
}
