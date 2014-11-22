namespace HouseStarkBlog.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Heading { get; set; }

        [Required]
        [StringLength(65535, MinimumLength = 20)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}