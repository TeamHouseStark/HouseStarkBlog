namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "ReplyCommentId" });
            RenameColumn(table: "dbo.Posts", name: "AuthorId", newName: "UserId");
            RenameIndex(table: "dbo.Posts", name: "IX_AuthorId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ReplyCommentId" });
            RenameIndex(table: "dbo.Posts", name: "IX_UserId", newName: "IX_AuthorId");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "AuthorId");
        }
    }
}
