namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstocktoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "stock");
        }
    }
}
