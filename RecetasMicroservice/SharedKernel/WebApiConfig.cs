using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System.Web.Http;

namespace RecetasMicroservice.SharedKernel
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración de Swagger
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Tu API")
                        .Description("Esta es una descripción de tu API.");
                    c.IncludeXmlComments(GetXmlCommentsPath()); // Agregar comentarios XML (opcional)
                })
                .EnableSwaggerUi(c =>
                {
                    // Personalización de la UI de Swagger
                    c.DocumentTitle("Documentación de Tu API"); // Cambiar el título de la página
                });

            // Configurar la serialización de JSON
            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented; // Para respuestas más legibles
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Usar camelCase para las propiedades

            // Eliminar el soporte para XML (opcional)
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\RecetasMicroservice.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
