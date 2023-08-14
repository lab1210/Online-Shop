namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtotaltocart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Total");
        }
    }
}
