namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.EmployeeApplications", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.GuardianAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.StudentAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.StudentApplications", "OccupationId", "dbo.Occupations");
            DropIndex("dbo.StudentApplications", new[] { "OccupationId" });
            DropIndex("dbo.EmployeeAccounts", new[] { "OccupationId" });
            DropIndex("dbo.EmployeeApplications", new[] { "OccupationId" });
            DropIndex("dbo.StudentAccounts", new[] { "OccupationId" });
            DropIndex("dbo.GuardianAccounts", new[] { "OccupationId" });
            AddColumn("dbo.StudentApplications", "Occupation_Code", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeAccounts", "Occupation_Code", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeApplications", "Occupation_Code", c => c.String(maxLength: 128));
            AddColumn("dbo.StudentAccounts", "Occupation_Code", c => c.String(maxLength: 128));
            AddColumn("dbo.GuardianAccounts", "Occupation_Code", c => c.String(maxLength: 128));
            AlterColumn("dbo.StudentApplications", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeAccounts", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeApplications", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.StudentAccounts", "OccupationId", c => c.String(nullable: false));
            AlterColumn("dbo.GuardianAccounts", "OccupationId", c => c.String(nullable: false));
            CreateIndex("dbo.StudentApplications", "Occupation_Code");
            CreateIndex("dbo.EmployeeAccounts", "Occupation_Code");
            CreateIndex("dbo.EmployeeApplications", "Occupation_Code");
            CreateIndex("dbo.StudentAccounts", "Occupation_Code");
            CreateIndex("dbo.GuardianAccounts", "Occupation_Code");
            AddForeignKey("dbo.EmployeeAccounts", "Occupation_Code", "dbo.Occupations", "Code");
            AddForeignKey("dbo.EmployeeApplications", "Occupation_Code", "dbo.Occupations", "Code");
            AddForeignKey("dbo.GuardianAccounts", "Occupation_Code", "dbo.Occupations", "Code");
            AddForeignKey("dbo.StudentAccounts", "Occupation_Code", "dbo.Occupations", "Code");
            AddForeignKey("dbo.StudentApplications", "Occupation_Code", "dbo.Occupations", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentApplications", "Occupation_Code", "dbo.Occupations");
            DropForeignKey("dbo.StudentAccounts", "Occupation_Code", "dbo.Occupations");
            DropForeignKey("dbo.GuardianAccounts", "Occupation_Code", "dbo.Occupations");
            DropForeignKey("dbo.EmployeeApplications", "Occupation_Code", "dbo.Occupations");
            DropForeignKey("dbo.EmployeeAccounts", "Occupation_Code", "dbo.Occupations");
            DropIndex("dbo.GuardianAccounts", new[] { "Occupation_Code" });
            DropIndex("dbo.StudentAccounts", new[] { "Occupation_Code" });
            DropIndex("dbo.EmployeeApplications", new[] { "Occupation_Code" });
            DropIndex("dbo.EmployeeAccounts", new[] { "Occupation_Code" });
            DropIndex("dbo.StudentApplications", new[] { "Occupation_Code" });
            AlterColumn("dbo.GuardianAccounts", "OccupationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StudentAccounts", "OccupationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EmployeeApplications", "OccupationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EmployeeAccounts", "OccupationId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StudentApplications", "OccupationId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.GuardianAccounts", "Occupation_Code");
            DropColumn("dbo.StudentAccounts", "Occupation_Code");
            DropColumn("dbo.EmployeeApplications", "Occupation_Code");
            DropColumn("dbo.EmployeeAccounts", "Occupation_Code");
            DropColumn("dbo.StudentApplications", "Occupation_Code");
            CreateIndex("dbo.GuardianAccounts", "OccupationId");
            CreateIndex("dbo.StudentAccounts", "OccupationId");
            CreateIndex("dbo.EmployeeApplications", "OccupationId");
            CreateIndex("dbo.EmployeeAccounts", "OccupationId");
            CreateIndex("dbo.StudentApplications", "OccupationId");
            AddForeignKey("dbo.StudentApplications", "OccupationId", "dbo.Occupations", "Code", cascadeDelete: true);
            AddForeignKey("dbo.StudentAccounts", "OccupationId", "dbo.Occupations", "Code", cascadeDelete: true);
            AddForeignKey("dbo.GuardianAccounts", "OccupationId", "dbo.Occupations", "Code", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeApplications", "OccupationId", "dbo.Occupations", "Code", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAccounts", "OccupationId", "dbo.Occupations", "Code", cascadeDelete: true);
        }
    }
}
