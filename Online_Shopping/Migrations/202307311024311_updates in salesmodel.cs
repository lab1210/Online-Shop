namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesinsalesmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnRoutes", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VerifiedSales", "SaleDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VerifiedSales", "SaleDate");
            DropColumn("dbo.OnRoutes", "SaleDate");
        }
    }
}
