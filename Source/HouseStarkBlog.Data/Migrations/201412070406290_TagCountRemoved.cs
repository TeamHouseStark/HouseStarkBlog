namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagCountRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Count", c => c.Int(nullable: false));
        }
    }
}
