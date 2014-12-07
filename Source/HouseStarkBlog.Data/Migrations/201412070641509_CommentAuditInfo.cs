namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentAuditInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author", c => c.String(nullable: false));
            AddColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "ModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ModifiedOn");
            DropColumn("dbo.Comments", "CreatedOn");
            DropColumn("dbo.Comments", "Author");
        }
    }
}
