namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(false, true),
                    Heading = c.String(false, 150),
                    Content = c.String(false),
                    CreatedOn = c.DateTime(false),
                    AuthorId = c.Int(false),
                    Author_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            this.DropIndex("dbo.Posts", new[] {"Author_Id"});
            this.DropTable("dbo.Posts");
        }
    }

}