namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportwithimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReports", "imagepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReports", "imagepath");
        }
    }
}
