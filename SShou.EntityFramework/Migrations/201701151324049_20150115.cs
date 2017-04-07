namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150115 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpUsers1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50, unicode: false),
                        PassWord = c.String(maxLength: 50, unicode: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AbpUsers1");
        }
    }
}
