namespace HouseStarkBlog.Web.Api.Controllers
{

    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;
    using System.Web.Http.Results;

    using Data;
    using Data.Models;

    using Newtonsoft.Json;

    using ViewModels;

    [EnableCors(origins: "http://localhost:2992", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly AppDbContext db = new AppDbContext();

        /*
        // GET: api/User
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        */

        // GET: api/User/5
        [ResponseType(typeof (User))]
        public JsonResult<UserViewModel> GetUser(string id)
        {
            User user = this.db.Users.FirstOrDefault(u => u.Id == id);
            var requestedUser = new UserViewModel {Email = user.Email, UserName = user.UserName};

            return this.Json(requestedUser, new JsonSerializerSettings());
        }

        /*
        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
        */
    }

}