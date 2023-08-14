namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sales", "Address");
            DropColumn("dbo.Sales", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Sales", "Address", c => c.String(nullable: false));
        }
    }
}
