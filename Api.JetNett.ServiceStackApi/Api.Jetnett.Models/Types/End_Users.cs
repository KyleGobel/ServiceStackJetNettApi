using System;
using System.Collections.Generic;

namespace Api.Jetnett.Models.Models
{
    public partial class End_Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Client_ID { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public int Times_Used { get; set; }
        public Nullable<System.DateTime> Last_Date_Accessed { get; set; }
        public string Target_URL { get; set; }
        public string Zip_Code { get; set; }
        public Nullable<bool> OptInEmail { get; set; }
        public string Registration_ID_Used { get; set; }
        public Nullable<int> Classification_ID { get; set; }
        public Nullable<int> Times_Registered { get; set; }
        public string Age_Group { get; set; }
    }
}
