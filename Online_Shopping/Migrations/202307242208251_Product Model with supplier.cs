﻿namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelwithsupplier : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Discount_Price", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Products", "SupplierID");
            AddForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierID" });
            AlterColumn("dbo.Products", "Discount_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
