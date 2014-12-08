namespace HouseStarkBlog.Web.Api.ViewModels
{

    using System.Collections.Generic;

    public class CategoryDetailsViewModel : CategoryViewModel
    {
        public IList<PostViewModel> Posts { get; set; }
    }
}