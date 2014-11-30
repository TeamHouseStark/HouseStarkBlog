namespace HouseStarkBlog.Web.Api
{

    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute("TopPostsApi", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new {id = RouteParameter.Optional});
        }
    }

}