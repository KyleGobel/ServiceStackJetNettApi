using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Stack
    {
        public Stack()
        {
            this.Daily_EZ = new List<Daily_EZ>();
            this.MEG_v3 = new List<MEG_v3>();
        }

        public int ID { get; set; }
        public string Widgets { get; set; }
        public string Name { get; set; }
        public string Display_Name { get; set; }
        public Nullable<int> Height { get; set; }
        public virtual ICollection<Daily_EZ> Daily_EZ { get; set; }
        public virtual ICollection<MEG_v3> MEG_v3 { get; set; }
    }
}
