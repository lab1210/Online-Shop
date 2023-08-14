namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinSalesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Sales", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.Sales", "ExpiryDate");
            DropColumn("dbo.Sales", "CVV");
            DropColumn("dbo.Sales", "CardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "CardNumber", c => c.String(nullable: false));
            AddColumn("dbo.Sales", "CVV", c => c.String(nullable: false));
            AddColumn("dbo.Sales", "ExpiryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "Phone");
            DropColumn("dbo.Sales", "Address");
        }
    }
}
