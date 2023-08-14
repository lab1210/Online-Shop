namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbortedDeliveryupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbortedDeleveries", "Reason", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbortedDeleveries", "Reason", c => c.String());
        }
    }
}
