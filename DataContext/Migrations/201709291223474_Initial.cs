namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(maxLength: 512),
                        Values = c.String(unicode: false, storeType: "text"),
                        IsActive = c.Boolean(nullable: false),
                        IdUpdatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialPages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Description = c.String(maxLength: 256),
                        Content = c.String(),
                        SEOTitle = c.String(maxLength: 150),
                        SEODescription = c.String(maxLength: 150),
                        KeyWord = c.String(maxLength: 150),
                        PageId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        IdUpdatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Email = c.String(maxLength: 128),
                        Password = c.String(maxLength: 512),
                        IsActive = c.Boolean(nullable: false),
                        IdUpdatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.SpecialPages");
            DropTable("dbo.Settings");
        }
    }
}
