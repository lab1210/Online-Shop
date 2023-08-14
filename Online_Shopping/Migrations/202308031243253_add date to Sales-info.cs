namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatetoSalesinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInfoes", "SaleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "SaleDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesInfoes", "SaleDate");
        }
    }
}
