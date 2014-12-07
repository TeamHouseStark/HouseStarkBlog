namespace HouseStarkBlog.Web.Controllers
{

    using System.Web.Mvc;

    using Data.Models;

    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            return this.View();
        }

        // GET: Category/Create
        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Category category)
        {
            return this.View();
        }

        // GET: Category/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            return this.View();
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Category category)
        {
            return this.View();
        }

        // GET: Category/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            return this.View();
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return this.RedirectToAction("Index");
        }
    }

}