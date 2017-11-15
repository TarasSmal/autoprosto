namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lllo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IdRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IdRole");
        }
    }
}
