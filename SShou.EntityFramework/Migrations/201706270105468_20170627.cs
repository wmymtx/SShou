namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170627 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRecommends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recommender = c.String(maxLength: 50, unicode: false),
                        Recommended = c.String(maxLength: 50, unicode: false),
                        RecommenderId = c.Int(nullable: false),
                        JoinTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRecommends");
        }
    }
}
