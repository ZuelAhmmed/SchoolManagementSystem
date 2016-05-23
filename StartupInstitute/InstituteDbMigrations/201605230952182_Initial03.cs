namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Designations", "EmployeeCatagoryId", "dbo.SecurityRoles");
            DropIndex("dbo.Designations", new[] { "EmployeeCatagoryId" });
            AlterColumn("dbo.Designations", "EmployeeCatagoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Designations", "EmployeeCatagoryId");
            AddForeignKey("dbo.Designations", "EmployeeCatagoryId", "dbo.SecurityRoles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Designations", "EmployeeCatagoryId", "dbo.SecurityRoles");
            DropIndex("dbo.Designations", new[] { "EmployeeCatagoryId" });
            AlterColumn("dbo.Designations", "EmployeeCatagoryId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Designations", "EmployeeCatagoryId");
            AddForeignKey("dbo.Designations", "EmployeeCatagoryId", "dbo.SecurityRoles", "RoleId", cascadeDelete: true);
        }
    }
}
