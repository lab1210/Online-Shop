namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartModelwithimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "ImagePath");
        }
    }
}
