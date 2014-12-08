namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostVisitsCounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Visits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Visits");
        }
    }
}
