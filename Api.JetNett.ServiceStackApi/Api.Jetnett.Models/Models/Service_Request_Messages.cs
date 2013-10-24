using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Service_Request_Messages
    {
        public int ID { get; set; }
        public int Request_ID { get; set; }
        public int Message_Count { get; set; }
        public string Message { get; set; }
        public Nullable<bool> From_Tech { get; set; }
    }
}
