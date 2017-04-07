namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170225 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Unit", c => c.String(maxLength: 6, unicode: false));
            AddColumn("dbo.Products", "Unit", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Unit");
            DropColumn("dbo.OrderItems", "Unit");
        }
    }
}
