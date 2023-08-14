namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSalesinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInfoes", "Name", c => c.String());
            AddColumn("dbo.SalesInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SalesInfoes", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.SalesInfoes", "user", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesInfoes", "user");
            DropColumn("dbo.SalesInfoes", "Quantity");
            DropColumn("dbo.SalesInfoes", "Price");
            DropColumn("dbo.SalesInfoes", "Name");
        }
    }
}
