namespace HouseStarkBlog.Web.Api.ViewModels
{

    using System.Collections.Generic;

    using Data.Models;

    public class PostDetailsViewModel : PostViewModel
    {
        public int CategoryId { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IList<CommentViewModel> Comments { get; set; }
    }
}