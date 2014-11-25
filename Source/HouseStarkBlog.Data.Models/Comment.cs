namespace HouseStarkBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        private ICollection<Comment> comments;

        public Comment()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }

}