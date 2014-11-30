namespace HouseStarkBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }
        public virtual ICollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Count { get; set; }
        
    }
}