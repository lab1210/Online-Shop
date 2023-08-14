namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removereg : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Registers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
