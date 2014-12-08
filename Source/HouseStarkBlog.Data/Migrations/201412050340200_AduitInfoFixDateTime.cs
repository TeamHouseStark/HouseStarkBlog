namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class AduitInfoFixDateTime : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            this.DropIndex("dbo.Posts", new[] {"Category_Id"});
            this.RenameColumn("dbo.Posts", "Category_Id", "CategoryId");
            this.AlterColumn("dbo.Posts", "CategoryId", c => c.Int(false));
            this.CreateIndex("dbo.Posts", "CategoryId");
            this.AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", true);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            this.DropIndex("dbo.Posts", new[] {"CategoryId"});
            this.AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            this.RenameColumn("dbo.Posts", "CategoryId", "Category_Id");
            this.CreateIndex("dbo.Posts", "Category_Id");
            this.AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
    }

}