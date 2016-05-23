namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSecurityRoles", "EmailAddess", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSecurityRoles", "EmailAddess");
        }
    }
}
