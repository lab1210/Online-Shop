namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbortedDeliveryaddcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbortedDeleveries", "Customer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbortedDeleveries", "Customer");
        }
    }
}
