namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017031921 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SS_User", "JoinTime", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SS_User", "JoinTime");
        }
    }
}
