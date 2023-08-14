namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbortedDelivery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbortedDeleveries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AbortedDeleveries");
        }
    }
}
