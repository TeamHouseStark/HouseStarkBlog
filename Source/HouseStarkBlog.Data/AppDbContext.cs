namespace HouseStarkBlog.Data
{

    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }

}