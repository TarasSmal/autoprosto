namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class language : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialPages", "OriginalId", c => c.Int(nullable: false));
            AddColumn("dbo.SpecialPages", "IdLanguage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecialPages", "IdLanguage");
            DropColumn("dbo.SpecialPages", "OriginalId");
        }
    }
}
