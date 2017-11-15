namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "Image");
        }
    }
}
