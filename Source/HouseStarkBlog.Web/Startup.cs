﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseStarkBlog.Web.Startup))]
namespace HouseStarkBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
