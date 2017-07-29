namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170407eve : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MapRanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RangeName = c.String(maxLength: 30, unicode: false),
                        Lat_Lng = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MapRanges");
        }
    }
}
