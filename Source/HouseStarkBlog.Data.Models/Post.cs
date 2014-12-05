namespace HouseStarkBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using Interfaces;
    using System;

    [DataContract(IsReference = true)]
    public class Post : IAuditInfo
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        [DataMember]
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        [DataMember]
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(150, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [DataMember]
        [StringLength(65535, MinimumLength = 20)]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }

        [DataMember]
        public string UserId { get; set; }

        
        public virtual User User { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime? ModifiedOn { get; set; }
    }

}