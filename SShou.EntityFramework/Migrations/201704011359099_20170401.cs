namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170401 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SS_User", "RecyclingCategoryId", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.SS_User", "RecyclingCategoryName", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SS_User", "RecyclingCategoryName", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.SS_User", "RecyclingCategoryId", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
