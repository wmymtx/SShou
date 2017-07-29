namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170628 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointsLogs", "SourceType", c => c.Int(nullable: false));
            AddColumn("dbo.PointsLogs", "FK_ID", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointsLogs", "FK_ID");
            DropColumn("dbo.PointsLogs", "SourceType");
        }
    }
}
