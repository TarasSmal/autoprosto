namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSprcialPages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialPages", "PageImage", c => c.String(maxLength: 256));
            AlterColumn("dbo.Settings", "Values", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Values", c => c.String(unicode: false, storeType: "text"));
            DropColumn("dbo.SpecialPages", "PageImage");
        }
    }
}
