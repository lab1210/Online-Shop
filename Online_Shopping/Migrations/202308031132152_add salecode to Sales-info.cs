namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsalecodetoSalesinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInfoes", "SaleCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesInfoes", "SaleCode");
        }
    }
}
