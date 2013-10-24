using ServiceStack.DataAnnotations;

namespace Api.Jetnett.Models.Models
{
    [Alias("Clients")]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Alias("User_Id")]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        [Alias("Display_Name")]
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Css { get; set; }
        [Alias("Analytics_Key")]
        public string AnalyticsKey { get; set; }
    }
}
