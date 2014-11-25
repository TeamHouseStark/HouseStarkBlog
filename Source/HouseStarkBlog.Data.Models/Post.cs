namespace HouseStarkBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(65535, MinimumLength = 20)]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }
        

    }

}