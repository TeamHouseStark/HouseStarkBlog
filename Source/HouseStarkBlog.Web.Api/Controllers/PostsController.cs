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
    using System.Web.Mvc;

    using Data;
    using Data.Models;

    using Newtonsoft.Json;

    using Ninject.Infrastructure.Language;

    using ViewModels;

    [EnableCors(origins: "http://localhost:2992", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/Posts
        public JsonResult<IEnumerable<PostViewModel>> GetPosts()
        {
            var posts = this.db.Posts.
                OrderByDescending(p => p.CreatedOn).
                Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Author = p.User.UserName,
                    Category = p.Category.Title,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    ModifiedOn = p.ModifiedOn,
                    Visits = p.Visits
                });

            return this.Json(posts.ToEnumerable(), new JsonSerializerSettings());
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public JsonResult<PostDetailsViewModel> GetPost(int id)
        {
            var post = this.db.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                var requestedPost = new PostDetailsViewModel
                {
                    Id = post.Id,
                    Author = post.User.UserName,
                    Category = post.Category.Title,
                    Comments = post.Comments.Select(c => new CommentViewModel
                    {
                        Author = c.Author,
                        Content = c.Content,
                        CreatedOn = c.CreatedOn,
                        ModifiedOn = c.ModifiedOn
                    }).ToList(),
                    Content = post.Content,
                    CreatedOn = post.CreatedOn,
                    ModifiedOn = post.ModifiedOn,
                    Tags = post.Tags.Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Title = t.Name
                    }).ToEnumerable(),
                    Title = post.Title,
                    AuthorId = post.UserId,
                    CategoryId = post.CategoryId,
                    Visits = post.Visits
                };

                // get comments` reply
                if (post.Comments != null)
                {
                    var comments = post.Comments.ToList();
                    for (int i = 0; i < comments.Count; i += 1)
                    {
                        var reply = comments[i].ReplyComment;
                        if (reply != null)
                        {
                            requestedPost.Comments[i].Reply = new CommentViewModel
                            {
                                Author = reply.Author,
                                Content = reply.Content,
                                CreatedOn = reply.CreatedOn,
                                ModifiedOn = reply.ModifiedOn
                            };
                        }
                    }
                }
                return this.Json(requestedPost, new JsonSerializerSettings());
            }

            return Json(default(PostDetailsViewModel), new JsonSerializerSettings());
        }

        [System.Web.Http.HttpGet]
        public JsonResult<IEnumerable<PostViewModel>> TopPosts([FromUri] int limit)
        {
            var posts = this.db.Posts.
                OrderByDescending(p => p.CreatedOn).
                Take(limit).
                Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Author = p.User.UserName,
                    Category = p.Category.Title,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    ModifiedOn = p.ModifiedOn,
                    Visits = p.Visits
                });

            return this.Json(posts.ToEnumerable(), new JsonSerializerSettings());
        }

            // PUT: api/Posts/5
        [ResponseType(typeof(void))]
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
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(PostTagRequest reqModel)
        {
            var post = new Post 
            {
                UserId = reqModel.UserId,
                Title = reqModel.Title,
                Content = reqModel.Content,
                CategoryId = reqModel.CategoryId,
                Visits = 0
            };

            if(reqModel.Tags.Length > 0)
            {
                foreach(var name in reqModel.Tags) 
                {
                    var tag = this.db.Tags.FirstOrDefault(t => t.Name == name);
                    if(tag != null)
                    {
                        post.Tags.Add(tag);
                    }
                }
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Posts.Add(post);
            this.db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
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