namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlistofcarttosale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Sale_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Sale_Id");
            AddForeignKey("dbo.Carts", "Sale_Id", "dbo.Sales", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.Carts", new[] { "Sale_Id" });
            DropColumn("dbo.Carts", "Sale_Id");
        }
    }
}
