using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class CAL_History
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public Nullable<int> CAL_Added { get; set; }
        public Nullable<System.DateTime> Date_Added { get; set; }
    }
}
