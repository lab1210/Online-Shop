namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartModelwithuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "UserName");
        }
    }
}
