using System;
using System.Collections.Generic;

namespace Api.JetNett.Models.Models
{
    public partial class Folder
    {
        public Folder()
        {
            this.Folders1 = new List<Folder>();
            this.Pages = new List<Page>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Parent_Folder_ID { get; set; }
        public virtual ICollection<Folder> Folders1 { get; set; }
        public virtual Folder Folder1 { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
