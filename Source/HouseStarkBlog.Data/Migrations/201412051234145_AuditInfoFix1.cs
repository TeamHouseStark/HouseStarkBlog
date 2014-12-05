namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditInfoFix1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(nullable: false));
        }
    }
}
