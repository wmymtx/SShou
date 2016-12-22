namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrders1220 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Remark", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Remark");
        }
    }
}
