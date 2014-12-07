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
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/Category
        public JsonResult<IEnumerable<CategoryViewModel>> GetCategories()
        {

            var categories = this.db.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();

            return Json(categories.ToEnumerable(), new JsonSerializerSettings());
        }

        // GET: api/Category/5
        [ResponseType(typeof (Category))]
        public JsonResult<CategoryDetailsViewModel> GetCategory(int id)
        {
            var category = this.db.Categories.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                var requestedCategory = new CategoryDetailsViewModel
                {
                    Id = category.Id,
                    Title = category.Title
                };
                if (category.Posts != null)
                {
                    requestedCategory.Posts = category.Posts.Select(p => new PostViewModel
                    {
                        Id = p.Id,
                        Author = p.User.UserName,
                        Category = p.Category.Title,
                        Content = p.Content,
                        CreatedOn = p.CreatedOn,
                        ModifiedOn = p.ModifiedOn,
                        Title = p.Title
                    }).ToList();
                }
                return Json(requestedCategory, new JsonSerializerSettings());
            }

            return this.Json(default(CategoryDetailsViewModel), new JsonSerializerSettings());
        }

        // PUT: api/Category/5
        [ResponseType(typeof (void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != category.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(category).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CategoryExists(id))
                {
                    return this.NotFound();
                }
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Category
        [ResponseType(typeof (Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Categories.Add(category);
            this.db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = category.Id}, category);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof (Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = this.db.Categories.Find(id);
            if (category == null)
            {
                return this.NotFound();
            }

            this.db.Categories.Remove(category);
            this.db.SaveChanges();

            return this.Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return this.db.Categories.Count(e => e.Id == id) > 0;
        }
    }

}