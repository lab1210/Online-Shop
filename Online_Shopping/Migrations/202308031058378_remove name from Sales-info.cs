namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenamefromSalesinfo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SalesInfoes", "Name");
            DropColumn("dbo.SalesInfoes", "Price");
            DropColumn("dbo.SalesInfoes", "Quantity");
            DropColumn("dbo.SalesInfoes", "user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInfoes", "user", c => c.String());
            AddColumn("dbo.SalesInfoes", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.SalesInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SalesInfoes", "Name", c => c.String());
        }
    }
}
