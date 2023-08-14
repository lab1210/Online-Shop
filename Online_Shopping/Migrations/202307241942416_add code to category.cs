namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcodetocategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Code");
        }
    }
}
