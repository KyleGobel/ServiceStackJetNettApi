using ServiceStack.DataAnnotations;

namespace Api.JetNett.Models.Types
{
    [Alias("Clients")]
    public class Client
    {
        [AutoIncrement]
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

        public override bool Equals(object obj)
        {
            var client = (obj as Client);
            return client != null && client.Id.Equals(this.Id); 
        }
    }
}
