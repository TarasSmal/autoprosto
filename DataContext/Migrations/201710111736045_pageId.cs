namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pageId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "PageId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "PageId");
        }
    }
}
