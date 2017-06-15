using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace RunningJournalApi
{
    /// <summary>
    /// BootStrap class
    /// </summary>
    public class Bootstrap
    {
        public Bootstrap()
        {
        }

        public void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new
                {
                    controller = "Journal",
                    id = RouteParameter.Optional
                });

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}