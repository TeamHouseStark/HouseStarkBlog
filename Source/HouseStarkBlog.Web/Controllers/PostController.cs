namespace HouseStarkBlog.Web.Controllers
{

    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Web.Mvc;

    using Data.Models;

    using Newtonsoft.Json;

    public class PostController : Controller
    {

        // GET: Post

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create("http://localhost:6859/api/Posts");
            request.Method = "GET";

            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            string result = string.Empty;
            if (stream != null)
            {
                var reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }

            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(result);

            return this.View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var post = new Post();
            return View(post);
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
