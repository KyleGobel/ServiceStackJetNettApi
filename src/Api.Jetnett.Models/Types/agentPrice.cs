using System;
using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("AgentPrices")]
    public class AgentPrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
