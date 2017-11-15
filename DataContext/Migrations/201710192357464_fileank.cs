namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdType = c.Int(nullable: false),
                        Note = c.String(),
                        Path = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        IdUpdatedBy = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileBanks");
        }
    }
}
