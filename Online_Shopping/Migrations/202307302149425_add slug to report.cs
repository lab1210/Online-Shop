namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addslugtoreport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReports", "slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReports", "slug");
        }
    }
}
