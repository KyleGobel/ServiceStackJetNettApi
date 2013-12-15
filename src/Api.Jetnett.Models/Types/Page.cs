using System;
using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Pages")]
    public class Page
    {
        [Alias("ID")]
        [AutoIncrement]
        public int Id { get; set; }

        [Alias("Folder_ID")]
        [ForeignKey(typeof(Folder), OnDelete="CASCADE", OnUpdate="CASCADE")]
        public int FolderId { get; set; }

        public string Title { get; set; }

        [Alias("Auto_Ordering")]
        public bool? AutoOrdering { get; set; }

        [Alias("Footer_HTML")]
        public string FooterHtml { get; set; }


        public string MetaKeys { get; set; }
        public string MetaDesc { get; set; }

        [Alias("Canonical_URL")]
        public string CanonicalUrl { get; set; }

        [Alias("Extra_HTML")]
        public string HeaderHtml { get; set; }

        public string Route { get; set; }

        public override bool Equals(object obj)
        {
            var page = obj as Page;
            if (page == null)
                return false;
            return (this.Id.Equals(page.Id) && this.FolderId.Equals(page.FolderId));
        }
    }
}
