namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Created_By = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.PurchasedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.ProductID)
                .Index(t => t.Purchase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.PurchasedProducts", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchasedProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchasedProducts", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchasedProducts", new[] { "ProductID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropTable("dbo.PurchasedProducts");
            DropTable("dbo.Purchases");
        }
    }
}
