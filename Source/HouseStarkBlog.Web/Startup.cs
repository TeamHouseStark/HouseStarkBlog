using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseStarkBlog.Data.Startup))]
namespace HouseStarkBlog.Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
