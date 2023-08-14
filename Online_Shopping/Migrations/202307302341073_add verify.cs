namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addverify : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VerifiedSales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Address = c.String(),
                        Driver = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VerifiedSales");
        }
    }
}
