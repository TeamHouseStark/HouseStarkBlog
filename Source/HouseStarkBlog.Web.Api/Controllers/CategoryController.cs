namespace HouseStarkBlog.Web.Api.Controllers
{

    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;
    using System.Web.Http.Results;

    using Data;
    using Data.Models;

    using Newtonsoft.Json;

    using Ninject.Infrastructure.Language;

    using ViewModels;

    [EnableCors(origins: "http://localhost:2992", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Category
        public JsonResult<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return Json(this.db.Categories.Select(c => new CategoryViewModel() {Id = c.Id, Title = c.Title}).ToEnumerable(), new JsonSerializerSettings());
        }

        // GET: api/Category/5
        [ResponseType(typeof(Category))]
        public JsonResult<CategoryViewModel> GetCategory(int id)
        {
            Category category = db.Categories.Find(id);

            return Json(new CategoryViewModel() {Id = category.Id, Title = category.Title}, new JsonSerializerSettings());
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Category
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}