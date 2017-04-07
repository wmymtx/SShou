namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201703192219 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SS_User", "ID_Card", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SS_User", "ID_Card");
        }
    }
}
