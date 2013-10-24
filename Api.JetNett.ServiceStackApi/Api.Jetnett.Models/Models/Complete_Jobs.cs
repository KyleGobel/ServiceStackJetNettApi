using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Complete_Jobs
    {
        public int Job_ID { get; set; }
        public Nullable<System.DateTime> Started { get; set; }
        public Nullable<System.DateTime> Finished { get; set; }
    }
}
