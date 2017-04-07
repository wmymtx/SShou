namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170305 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SS_User", "Weixin", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.SS_User", "OpenId", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.SS_User", "Province", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.SS_User", "City", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.SS_User", "County", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.SS_User", "FirstAddress", c => c.String(unicode: false));
            AddColumn("dbo.SS_User", "WorkingTime", c => c.String(maxLength: 20, unicode: false));
            AddColumn("dbo.SS_User", "RecyclingCategoryId", c => c.String(maxLength: 20, unicode: false));
            AddColumn("dbo.SS_User", "RecyclingCategoryName", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SS_User", "RecyclingCategoryName");
            DropColumn("dbo.SS_User", "RecyclingCategoryId");
            DropColumn("dbo.SS_User", "WorkingTime");
            DropColumn("dbo.SS_User", "FirstAddress");
            DropColumn("dbo.SS_User", "County");
            DropColumn("dbo.SS_User", "City");
            DropColumn("dbo.SS_User", "Province");
            DropColumn("dbo.SS_User", "OpenId");
            DropColumn("dbo.SS_User", "Weixin");
        }
    }
}
