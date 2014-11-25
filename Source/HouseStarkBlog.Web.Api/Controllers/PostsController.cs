namespace HouseStarkBlog.Web.Api.Controllers
{

    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Http.Results;
    using System.Web.Mvc;

    using Data;
    using Data.Models;

    using Newtonsoft.Json;

    using Ninject.Infrastructure.Language;

    public class PostsController : ApiController
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/Posts
        public JsonResult<IEnumerable<Post>> GetPosts()
        {
            return Json(this.db.Posts.ToEnumerable(), new JsonSerializerSettings());
        }

        // GET: api/Posts/5
        [ResponseType(typeof (Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof (void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != post.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(post).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.PostExists(id))
                {
                    return this.NotFound();
                }
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof (Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Posts.Add(post);
            this.db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = post.Id}, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof (Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.NotFound();
            }

            this.db.Posts.Remove(post);
            this.db.SaveChanges();

            return this.Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return this.db.Posts.Count(e => e.Id == id) > 0;
        }
    }

}