namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class AuditInfoFix : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            this.DropIndex("dbo.Posts", new[] {"CategoryId"});
            this.RenameColumn("dbo.Posts", "CategoryId", "Category_Id");
            this.AlterColumn("dbo.Posts", "Category_Id", c => c.Int());
            this.CreateIndex("dbo.Posts", "Category_Id");
            this.AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            this.DropIndex("dbo.Posts", new[] {"Category_Id"});
            this.AlterColumn("dbo.Posts", "Category_Id", c => c.Int(false));
            this.RenameColumn("dbo.Posts", "Category_Id", "CategoryId");
            this.CreateIndex("dbo.Posts", "CategoryId");
            this.AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", true);
        }
    }

}