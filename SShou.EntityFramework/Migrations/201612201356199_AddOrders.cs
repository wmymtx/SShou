namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        F_OrderId = c.String(maxLength: 30, unicode: false),
                        ProductName = c.String(maxLength: 30, unicode: false),
                        ProductNum = c.Int(nullable: false),
                        ProductId = c.String(maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.F_OrderId)
                .Index(t => t.F_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 30, unicode: false),
                        UserId = c.String(maxLength: 30, unicode: false),
                        OrderTime = c.DateTime(precision: 0),
                        Address = c.String(maxLength: 80, unicode: false),
                        RecTime = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AlterColumn("dbo.Products", "Prcd_Name", c => c.String(maxLength: 16, storeType: "nvarchar"));
            AlterColumn("dbo.Products", "Prcd_ImgPath", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "F_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "F_OrderId" });
            AlterColumn("dbo.Products", "Prcd_ImgPath", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Products", "Prcd_Name", c => c.String(maxLength: 30, storeType: "nvarchar"));
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
