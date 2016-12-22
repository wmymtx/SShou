namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class or : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ProsonId", c => c.String(maxLength: 20, unicode: false));
            AddColumn("dbo.Orders", "PersonName", c => c.String(maxLength: 20, unicode: false));
            AddColumn("dbo.Orders", "PhoneNo", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PhoneNo");
            DropColumn("dbo.Orders", "PersonName");
            DropColumn("dbo.Orders", "ProsonId");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
