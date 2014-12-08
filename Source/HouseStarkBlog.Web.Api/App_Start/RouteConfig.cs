namespace HouseStarkBlog.Web.Api
{

    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "TopPosts",
                routeTemplate: "{controller}/Top/{limit}",
                defaults: new { controller = "Posts", action = "TopPosts" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HouseStarkBlog.Web.Api.Controllers" });
        }
    }

}