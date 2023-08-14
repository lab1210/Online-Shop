namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalecodetoonrouteandverifiedsale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnRoutes", "SaleCode", c => c.Int(nullable: false));
            AddColumn("dbo.VerifiedSales", "SaleCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VerifiedSales", "SaleCode");
            DropColumn("dbo.OnRoutes", "SaleCode");
        }
    }
}
