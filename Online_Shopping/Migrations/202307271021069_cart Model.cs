namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "NewCart_Id", "dbo.Carts");
            DropIndex("dbo.Sales", new[] { "NewCart_Id" });
            DropIndex("dbo.Carts", new[] { "Sale_Id" });
            DropColumn("dbo.Sales", "NewCart_Id");
            DropColumn("dbo.Carts", "Sale_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Sale_Id", c => c.Int());
            AddColumn("dbo.Sales", "NewCart_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Sale_Id");
            CreateIndex("dbo.Sales", "NewCart_Id");
            AddForeignKey("dbo.Sales", "NewCart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Carts", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
