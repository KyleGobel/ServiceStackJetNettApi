using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class Metro_eGuide_By_Email_End_User
    {
        public int client_id { get; set; }
        public int eu_id { get; set; }
        public string eu_name { get; set; }
        public string eu_first_name { get; set; }
        public string eu_email { get; set; }
        public string eu_code { get; set; }
        public string eu_sentby { get; set; }
        public int eu_download_try { get; set; }
        public bool eu_download_success { get; set; }
        public System.DateTime eu_created_date { get; set; }
        public Nullable<System.DateTime> eu_download_date { get; set; }
        public string eu_email_msg { get; set; }
        public string eu_address { get; set; }
        public string eu_city { get; set; }
        public string eu_state { get; set; }
        public string eu_zip { get; set; }
        public string eu_phone { get; set; }
        public string sales_agent { get; set; }
        public string eu_src { get; set; }
        public Nullable<bool> email_sent { get; set; }
        public string eu_subject { get; set; }
        public int id { get; set; }
    }
}
