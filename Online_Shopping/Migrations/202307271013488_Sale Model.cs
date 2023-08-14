namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleDate = c.DateTime(nullable: false),
                        NewCart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.NewCart_Id)
                .Index(t => t.NewCart_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.ProductID)
                .Index(t => t.Sale_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "NewCart_Id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Sale_Id" });
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropIndex("dbo.Sales", new[] { "NewCart_Id" });
            DropTable("dbo.Carts");
            DropTable("dbo.Sales");
        }
    }
}
