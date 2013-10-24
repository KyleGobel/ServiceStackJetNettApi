using Api.Jetnett.Models.Models;
using System.Linq;
namespace Api.Jetnett.Models.TableMappings
{
    public static class MappingMixins
    {
        public static Client ToEntity(this Clients This)
        {
            return new Client()
                {
                    AnalyticsKey = This.Analytics_Key,
                    Css = This.CSS,
                    DisplayName = This.Display_Name,
                    Email = This.Email,
                    Id = This.ID,
                    Name = This.Name,
                    Password = This.Password,
                    UserId = This.User_ID,
                    Website = This.Website
                };
        }
        public static Clients ToDatabaseMapEntity(this Client This)
        {
           return new Clients()
               {
                   Analytics_Key = This.AnalyticsKey,
                   CSS = This.Css,
                   Display_Name = This.DisplayName,
                   Email = This.Email,
                   ID = This.Id,
                   Name = This.Name,
                   Password = This.Password,
                   User_ID =  This.UserId,
                   Website = This.Website
               };
        }
    }
}