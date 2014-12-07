namespace HouseStarkBlog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    public partial class AuditInfoFix1 : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime());
        }

        public override void Down()
        {
            this.AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(false));
        }
    }

}