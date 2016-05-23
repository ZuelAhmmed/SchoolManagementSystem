namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial07 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserSecurityRoles", "RoleId", "dbo.SecurityRoles");
            DropIndex("dbo.UserSecurityRoles", new[] { "RoleId" });
            AlterColumn("dbo.UserSecurityRoles", "RoleId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSecurityRoles", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserSecurityRoles", "RoleId");
            AddForeignKey("dbo.UserSecurityRoles", "RoleId", "dbo.SecurityRoles", "RoleId");
        }
    }
}
