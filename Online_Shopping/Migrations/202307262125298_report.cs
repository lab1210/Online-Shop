namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        InStockQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductReports");
        }
    }
}
