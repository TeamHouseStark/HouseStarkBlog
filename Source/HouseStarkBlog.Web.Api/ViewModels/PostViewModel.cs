namespace HouseStarkBlog.Web.Api.ViewModels
{

    using System;

    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int Visits { get; set; }

    }
}