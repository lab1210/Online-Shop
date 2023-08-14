namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productwithdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "description");
        }
    }
}
