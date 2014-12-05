namespace HouseStarkBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditInfoFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Posts", "Category_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Category_Id");
            AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            AlterColumn("dbo.Posts", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Posts", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
