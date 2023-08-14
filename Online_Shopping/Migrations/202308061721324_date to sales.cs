namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetosales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesInfoes", "SaleDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInfoes", "SaleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "SaleDate");
        }
    }
}
