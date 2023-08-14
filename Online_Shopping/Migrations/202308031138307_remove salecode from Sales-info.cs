namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesalecodefromSalesinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesInfoes", "user", c => c.String());
            DropColumn("dbo.SalesInfoes", "SaleCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInfoes", "SaleCode", c => c.Int(nullable: false));
            DropColumn("dbo.SalesInfoes", "user");
        }
    }
}
