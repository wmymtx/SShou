namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170319 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SS_User", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SS_User", "Status");
        }
    }
}
