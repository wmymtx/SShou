namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170226 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        F_OrderId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Comment = c.String(maxLength: 100, unicode: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReMark = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.F_OrderId)
                .Index(t => t.F_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderComments", "F_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderComments", new[] { "F_OrderId" });
            DropTable("dbo.OrderComments");
        }
    }
}
