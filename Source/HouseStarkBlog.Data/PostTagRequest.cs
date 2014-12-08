namespace HouseStarkBlog.Data
{
    public class PostTagRequest
    {
        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public string[] Tags { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
