namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "Image");
        }
    }
}
