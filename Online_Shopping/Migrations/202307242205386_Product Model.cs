namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount_Price = c.Decimal(nullable: true, precision: 18, scale: 2),
                        SKU = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        imagepath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Products");
        }
    }
}
