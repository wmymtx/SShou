namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170206 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeUsers", "Invit_Code", c => c.Int(nullable: false));
            AddColumn("dbo.WeUsers", "Recommend_Code", c => c.Int(nullable: false));
            AddColumn("dbo.SS_User", "LoginName", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.SS_User", "UserName", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.SS_User", "PassWord", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.SS_User", "PhoneNo", c => c.String(maxLength: 11, unicode: false));
            AlterColumn("dbo.SS_User", "Address", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SS_User", "Address", c => c.String(unicode: false));
            AlterColumn("dbo.SS_User", "PhoneNo", c => c.String(unicode: false));
            AlterColumn("dbo.SS_User", "PassWord", c => c.String(unicode: false));
            AlterColumn("dbo.SS_User", "UserName", c => c.String(unicode: false));
            DropColumn("dbo.SS_User", "LoginName");
            DropColumn("dbo.WeUsers", "Recommend_Code");
            DropColumn("dbo.WeUsers", "Invit_Code");
        }
    }
}
