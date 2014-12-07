namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class AuditInfo : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Posts", "CreatedOn", c => c.DateTime(false));
            this.AddColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(false));
            this.AddColumn("dbo.Posts", "PreserveCreatedOn", c => c.Boolean(false));
            this.AlterColumn("dbo.Categories", "Title", c => c.String(false));
        }

        public override void Down()
        {
            this.AlterColumn("dbo.Categories", "Title", c => c.String());
            this.DropColumn("dbo.Posts", "PreserveCreatedOn");
            this.DropColumn("dbo.Posts", "ModifiedOn");
            this.DropColumn("dbo.Posts", "CreatedOn");
        }
    }

}