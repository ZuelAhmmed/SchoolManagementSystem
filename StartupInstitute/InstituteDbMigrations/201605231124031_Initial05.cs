namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeApplications", "ConfirmationId", "dbo.ConfirmationCatagories");
            DropForeignKey("dbo.EmployeeAccounts", "ConfirmationId", "dbo.ConfirmationCatagories");
            DropIndex("dbo.EmployeeAccounts", new[] { "ConfirmationId" });
            DropIndex("dbo.EmployeeApplications", new[] { "ConfirmationId" });
            AlterColumn("dbo.EmployeeAccounts", "ConfirmationId", c => c.String());
            AlterColumn("dbo.EmployeeApplications", "ConfirmationId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeApplications", "ConfirmationId", c => c.String(maxLength: 128));
            AlterColumn("dbo.EmployeeAccounts", "ConfirmationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmployeeApplications", "ConfirmationId");
            CreateIndex("dbo.EmployeeAccounts", "ConfirmationId");
            AddForeignKey("dbo.EmployeeAccounts", "ConfirmationId", "dbo.ConfirmationCatagories", "Code");
            AddForeignKey("dbo.EmployeeApplications", "ConfirmationId", "dbo.ConfirmationCatagories", "Code");
        }
    }
}
