namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removequantiyfromproduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "InStockQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "InStockQuantity", c => c.Int(nullable: false));
        }
    }
}
