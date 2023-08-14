namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsuppliertopurchaseproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasedProducts", "Supplier_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchasedProducts", "Supplier_Name");
        }
    }
}
