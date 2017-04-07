namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170118 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeUsers", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Type");
            DropColumn("dbo.WeUsers", "UserType");
        }
    }
}
