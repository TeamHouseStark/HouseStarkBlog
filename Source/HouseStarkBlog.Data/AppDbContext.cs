namespace HouseStarkBlog.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public System.Data.Entity.DbSet<HouseStarkBlog.Data.Models.Post> Posts { get; set; }
    }
}
