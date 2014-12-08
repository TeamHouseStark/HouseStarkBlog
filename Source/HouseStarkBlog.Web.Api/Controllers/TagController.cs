namespace HouseStarkBlog.Web.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Results;

    using Newtonsoft.Json;
    using Ninject.Infrastructure.Language;

    using Data;
    using ViewModels;

    [EnableCors(origins: "http://localhost:2992", headers: "*", methods: "*")]
    public class TagController : ApiController
    {
        private readonly AppDbContext db = new AppDbContext();

        public JsonResult<IEnumerable<TagViewModel>> GetTags()
        {
            var tags = this.db.Tags.Select(t => new TagViewModel
            {
                Id = t.Id,
                Title = t.Name

            }).ToEnumerable();

            return Json(tags, new JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult<IEnumerable<TagViewModel>> TopTag([FromUri] int limit)
        {
            var tags = this.db.Tags.
                OrderBy(t => t.Count).
                Take(limit).
                Select(t => new TagViewModel 
                {
                    Id = t.Id,
                    Title = t.Name
                });

            return Json(tags.ToEnumerable(), new JsonSerializerSettings());
        }
    }
}