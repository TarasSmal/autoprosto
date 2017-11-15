namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class respo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Respons",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        UserName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IdUpdatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Respons");
        }
    }
}
