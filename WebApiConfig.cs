namespace Wb.ClientesTest.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*"));
            config.Formatters.Add(new BrowserJsonFormatter());

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "MiComprobante33",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
            );
        }
    }

    public sealed class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SerializerSettings.Formatting = Formatting.Indented;
            SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public sealed override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
        }
    }
}
