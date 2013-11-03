using System;
using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Pages")]
    public class Page
    {
        [Alias("ID")]
        public int Id { get; set; }

        [Alias("Folder_ID")]
        public int FolderId { get; set; }

        public string Title { get; set; }

        [Alias("Auto_Ordering")]
        public Nullable<bool> AutoOrdering { get; set; }

        [Alias("Footer_HTML")]
        public string FooterHtml { get; set; }


        public string MetaKeys { get; set; }
        public string MetaDesc { get; set; }

        [Alias("Canonical_URL")]
        public string CanonicalUrl { get; set; }

        [Alias("Extra_HTML")]
        public string HeaderHtml { get; set; }

        public string Route { get; set; }
  
    }
}
