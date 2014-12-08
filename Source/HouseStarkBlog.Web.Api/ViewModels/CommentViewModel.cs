namespace HouseStarkBlog.Web.Api.ViewModels
{

    using System;

    public class CommentViewModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public CommentViewModel Reply { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}