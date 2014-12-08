namespace HouseStarkBlog.Web.Controllers
{

    using System.Web.Mvc;

    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            return this.View();
        }

        // GET: Post/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return this.View();
        }

        // GET: Post/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return this.View();
        }
    }

}