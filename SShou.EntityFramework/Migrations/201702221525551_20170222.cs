namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RecUserName", c => c.String(maxLength: 80, storeType: "nvarchar"));
            AddColumn("dbo.Orders", "RecPhone", c => c.String(maxLength: 11, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RecPhone");
            DropColumn("dbo.Orders", "RecUserName");
        }
    }
}
