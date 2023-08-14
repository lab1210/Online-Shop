namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddatetologin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Login_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Login_Date");
        }
    }
}
