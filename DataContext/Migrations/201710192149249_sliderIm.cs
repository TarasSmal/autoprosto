namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderIm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Settings", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Image", c => c.String());
        }
    }
}
