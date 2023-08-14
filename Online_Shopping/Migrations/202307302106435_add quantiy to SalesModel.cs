namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquantiytoSalesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Quantity");
        }
    }
}
