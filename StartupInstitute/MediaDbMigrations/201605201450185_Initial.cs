namespace StartupInstitute.MediaDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TrackingId = c.String(),
                        TrackingRef = c.String(),
                        ImageFile = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
