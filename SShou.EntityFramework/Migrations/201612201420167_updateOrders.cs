namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("OrderItems", "F_OrderId", "Orders");
            DropIndex("OrderItems", new[] { "F_OrderId" });
            DropPrimaryKey("Orders");
            AddColumn("Orders", "Id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("OrderItems", "F_OrderId", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AddPrimaryKey("Orders", "Id");
            CreateIndex("OrderItems", "F_OrderId");
            AddForeignKey("OrderItems", "F_OrderId", "Orders", "Id");
            DropColumn("Orders", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("Orders", "OrderId", c => c.String(nullable: false, maxLength: 30, unicode: false));
            DropForeignKey("OrderItems", "F_OrderId", "Orders");
            DropIndex("OrderItems", new[] { "F_OrderId" });
            DropPrimaryKey("Orders");
            AlterColumn("OrderItems", "F_OrderId", c => c.String(maxLength: 30, unicode: false));
            DropColumn("Orders", "Id");
            AddPrimaryKey("Orders", "OrderId");
            CreateIndex("OrderItems", "F_OrderId");
            AddForeignKey("OrderItems", "F_OrderId", "Orders", "OrderId");
        }
    }
}
