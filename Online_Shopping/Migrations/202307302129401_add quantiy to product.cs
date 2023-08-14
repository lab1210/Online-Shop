namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquantiytoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InStockQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "InStockQuantity");
        }
    }
}
