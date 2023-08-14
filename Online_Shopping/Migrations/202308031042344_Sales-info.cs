namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salesinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales", "SalesInfo_Id", c => c.Int());
            CreateIndex("dbo.Sales", "SalesInfo_Id");
            AddForeignKey("dbo.Sales", "SalesInfo_Id", "dbo.SalesInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "SalesInfo_Id", "dbo.SalesInfoes");
            DropIndex("dbo.Sales", new[] { "SalesInfo_Id" });
            DropColumn("dbo.Sales", "SalesInfo_Id");
            DropTable("dbo.SalesInfoes");
        }
    }
}
