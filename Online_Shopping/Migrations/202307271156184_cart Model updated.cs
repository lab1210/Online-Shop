namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartModelupdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductID" });
            AddColumn("dbo.Carts", "slug", c => c.String());
            DropColumn("dbo.Carts", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "slug");
            CreateIndex("dbo.Carts", "ProductID");
            AddForeignKey("dbo.Carts", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
