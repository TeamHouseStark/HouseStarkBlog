namespace HouseStarkBlog.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    using Interfaces;
    using System;

    public class Comment : IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [EmailAddress]
        public string Author { get; set; }

        public int? ReplyCommentId { get; set; }

        public Comment ReplyComment { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }

}