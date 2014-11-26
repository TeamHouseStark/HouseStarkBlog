namespace HouseStarkBlog.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    public class Comment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int AnswerCommentId { get; set; }

        public virtual Comment AnswerComment { get; set; }
    }

}