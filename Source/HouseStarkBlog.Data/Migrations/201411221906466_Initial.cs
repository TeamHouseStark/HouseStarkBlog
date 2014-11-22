namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropTable("dbo.Posts");
        }
    }
}
