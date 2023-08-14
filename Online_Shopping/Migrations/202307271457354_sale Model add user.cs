namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleModeladduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "user", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "user");
        }
    }
}
