namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleModelupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Name", c => c.String());
            AddColumn("dbo.Sales", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "ExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "CVV", c => c.String(nullable: false));
            AddColumn("dbo.Sales", "CardNumber", c => c.String(nullable: false));
            DropColumn("dbo.Sales", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Sales", "CardNumber");
            DropColumn("dbo.Sales", "CVV");
            DropColumn("dbo.Sales", "ExpiryDate");
            DropColumn("dbo.Sales", "Price");
            DropColumn("dbo.Sales", "Name");
        }
    }
}
