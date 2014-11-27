namespace HouseStarkBlog.Data
{

    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;

    using Models;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }

}