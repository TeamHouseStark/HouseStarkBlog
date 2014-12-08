namespace HouseStarkBlog.Web.Controllers
{

    using System.Linq;
    using System.Web.Mvc;

    using HouseStarkBlog.Data;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }

        public ActionResult Search(string query)
        {
            var db = new AppDbContext();
            var tags = db.Tags.Where(t => t.Name.Contains(query));

            //TODO
            //var posts = db.Posts.Where(p => p.Tags.Contains(tags.First()));

            foreach(var tag in tags) 
            {
                var posts = db.Posts.Where(p => p.Tags.Contains(tag));

                // merge results in one collection
                // maybe put this method in web api
            }

            return View();
        }
    }
}