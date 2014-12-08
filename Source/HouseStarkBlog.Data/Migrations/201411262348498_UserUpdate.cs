namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            this.DropIndex("dbo.Comments", new[] {"ReplyCommentId"});
            this.RenameColumn("dbo.Posts", "AuthorId", "UserId");
            this.RenameIndex("dbo.Posts", "IX_AuthorId", "IX_UserId");
        }

        public override void Down()
        {
            this.DropIndex("dbo.Comments", new[] {"ReplyCommentId"});
            this.RenameIndex("dbo.Posts", "IX_UserId", "IX_AuthorId");
            this.RenameColumn("dbo.Posts", "UserId", "AuthorId");
        }
    }

}