namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbortedDeliveryaddaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbortedDeleveries", "Address", c => c.String());
            AddColumn("dbo.AbortedDeleveries", "SaleDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbortedDeleveries", "SaleDate");
            DropColumn("dbo.AbortedDeleveries", "Address");
        }
    }
}
