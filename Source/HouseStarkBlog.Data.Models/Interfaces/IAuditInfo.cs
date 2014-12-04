using System;
namespace HouseStarkBlog.Data.Models.Interfaces
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }

        bool PreserveCreatedOn { get; set; }

    }
}
