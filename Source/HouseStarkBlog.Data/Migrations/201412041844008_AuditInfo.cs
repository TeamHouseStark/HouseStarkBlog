namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "PreserveCreatedOn", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Title", c => c.String());
            DropColumn("dbo.Posts", "PreserveCreatedOn");
            DropColumn("dbo.Posts", "ModifiedOn");
            DropColumn("dbo.Posts", "CreatedOn");
        }
    }
}
