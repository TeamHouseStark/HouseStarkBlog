namespace HouseStarkBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

    }
}
