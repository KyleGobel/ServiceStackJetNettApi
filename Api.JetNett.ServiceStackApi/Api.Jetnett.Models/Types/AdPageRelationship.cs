using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Ad_Page_Relationship")]
    public class AdPageRelationship
    {
        public int Id { get; set; }

        [Alias("Page_ID")]
        public int? PageId { get; set; }

        [Alias("Ad_Group")]
        public int? AdGroup { get; set; }

        [Alias("Broker_Code")]
        public string BrokerCode { get; set; }

        [Alias("Use_Broker_Code")]
        public bool UseBrokerCode { get; set; }

        [Alias("Client_ID")]
        public int? ClientId { get; set; }
    }
}
