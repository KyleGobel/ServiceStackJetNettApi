using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Contact_Page
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public int Page_ID { get; set; }
        public Nullable<int> Staff_1 { get; set; }
        public Nullable<int> Staff_2 { get; set; }
        public Nullable<int> Staff_3 { get; set; }
        public Nullable<int> Staff_4 { get; set; }
        public Nullable<int> Staff_5 { get; set; }
        public Nullable<int> Staff_6 { get; set; }
        public Nullable<int> Staff_7 { get; set; }
        public Nullable<int> Staff_8 { get; set; }
        public Nullable<int> Staff_9 { get; set; }
        public Nullable<int> Staff_10 { get; set; }
        public string Title { get; set; }
        public virtual Client Client { get; set; }
        public virtual Page Page { get; set; }
    }
}
