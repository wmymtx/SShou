namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170125 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeUsers", "IsInit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeUsers", "IsInit");
        }
    }
}
