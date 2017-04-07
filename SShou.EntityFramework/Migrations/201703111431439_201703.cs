namespace SShou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201703 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sort", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Sort");
        }
    }
}
