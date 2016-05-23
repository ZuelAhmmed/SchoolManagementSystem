namespace StartupInstitute.InstituteDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthRegNo = c.String(),
                        ClassOrYearId = c.String(),
                        SubjectId = c.String(),
                        WritenMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        McqTestMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PracticalMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AddressCatagories",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        NidOrBirthRegNo = c.String(),
                        AddressCatagory = c.String(nullable: false),
                        AddressRefCode = c.String(nullable: false),
                        HoldingBlockSector = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        BloodGroupCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BloodGroupCode);
            
            CreateTable(
                "dbo.ClassOrYears",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.StudentApplications",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        ClassOrYearId = c.String(nullable: false, maxLength: 128),
                        GuardianNid = c.String(nullable: false),
                        GroupId = c.String(nullable: false, maxLength: 128),
                        Shift = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        StudentConfirmId = c.String(maxLength: 128),
                        FamilyIncome = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 17),
                        Password = c.String(nullable: false, maxLength: 15),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(nullable: false, maxLength: 11),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        OccupationId = c.String(nullable: false, maxLength: 128),
                        FathersName = c.String(nullable: false),
                        FathersOccupation = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        MothersOccupation = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        MaritarialStatus = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        RegDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.ClassOrYears", t => t.ClassOrYearId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ConfirmationCatagories", t => t.StudentConfirmId)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.ClassOrYearId)
                .Index(t => t.GroupId)
                .Index(t => t.StudentConfirmId)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GroupCode);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ClassId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.String(nullable: false, maxLength: 128),
                        CatagoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SubjectCode)
                .ForeignKey("dbo.ClassOrYears", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectCatagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.GroupId)
                .Index(t => t.CatagoryId);
            
            CreateTable(
                "dbo.SubjectCatagories",
                c => new
                    {
                        SubCatCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubCatCode);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.EmployeeAccounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        EmployeeCatagoryId = c.String(maxLength: 128),
                        DesignationId = c.String(maxLength: 128),
                        SubjectCode = c.String(maxLength: 128),
                        IndexNumber = c.String(),
                        ConfirmationId = c.String(maxLength: 128),
                        ConfirmDate = c.DateTime(nullable: false),
                        ConfirmedBy = c.String(),
                        RetiredDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 17),
                        Password = c.String(nullable: false, maxLength: 15),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(nullable: false, maxLength: 11),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        OccupationId = c.String(nullable: false, maxLength: 128),
                        FathersName = c.String(nullable: false),
                        FathersOccupation = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        MothersOccupation = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        MaritarialStatus = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        RegDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.ConfirmationCatagories", t => t.ConfirmationId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .ForeignKey("dbo.SecurityRoles", t => t.EmployeeCatagoryId)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectCode)
                .Index(t => t.EmployeeCatagoryId)
                .Index(t => t.DesignationId)
                .Index(t => t.SubjectCode)
                .Index(t => t.ConfirmationId)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        EmployeeCatagoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DesignationCode)
                .ForeignKey("dbo.SecurityRoles", t => t.EmployeeCatagoryId, cascadeDelete: true)
                .Index(t => t.EmployeeCatagoryId);
            
            CreateTable(
                "dbo.SecurityRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeApplications",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        EmployeeCatagoryId = c.String(maxLength: 128),
                        DesignationId = c.String(maxLength: 128),
                        SubjectCode = c.String(maxLength: 128),
                        ConfirmationId = c.String(maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 17),
                        Password = c.String(nullable: false, maxLength: 15),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(nullable: false, maxLength: 11),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        OccupationId = c.String(nullable: false, maxLength: 128),
                        FathersName = c.String(nullable: false),
                        FathersOccupation = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        MothersOccupation = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        MaritarialStatus = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        RegDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .ForeignKey("dbo.SecurityRoles", t => t.EmployeeCatagoryId)
                .ForeignKey("dbo.ConfirmationCatagories", t => t.ConfirmationId)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectCode)
                .Index(t => t.EmployeeCatagoryId)
                .Index(t => t.DesignationId)
                .Index(t => t.SubjectCode)
                .Index(t => t.ConfirmationId)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.ConfirmationCatagories",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.StudentAccounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        ClassOrYearId = c.String(nullable: false, maxLength: 128),
                        ClassRollNo = c.Int(nullable: false),
                        GuardianNid = c.String(nullable: false),
                        GroupId = c.String(nullable: false, maxLength: 128),
                        Shift = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        FamilyIncome = c.Int(nullable: false),
                        StudentConfirmId = c.String(maxLength: 128),
                        ConfirmDate = c.DateTime(nullable: false),
                        ConfirmedBy = c.String(),
                        ExamPermissionId = c.String(),
                        PassingYear = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 17),
                        Password = c.String(nullable: false, maxLength: 15),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(nullable: false, maxLength: 11),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        OccupationId = c.String(nullable: false, maxLength: 128),
                        FathersName = c.String(nullable: false),
                        FathersOccupation = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        MothersOccupation = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        MaritarialStatus = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        RegDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.ClassOrYears", t => t.ClassOrYearId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .ForeignKey("dbo.ConfirmationCatagories", t => t.StudentConfirmId)
                .Index(t => t.ClassOrYearId)
                .Index(t => t.GroupId)
                .Index(t => t.StudentConfirmId)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.UserSecurityRoles",
                c => new
                    {
                        UserRoleId = c.String(nullable: false, maxLength: 128),
                        UserAccountId = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        NidOrBirthRegNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.SecurityRoles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.GuardianAccounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        FamilyIncome = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 17),
                        Password = c.String(nullable: false, maxLength: 15),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(nullable: false, maxLength: 11),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        OccupationId = c.String(nullable: false, maxLength: 128),
                        FathersName = c.String(nullable: false),
                        FathersOccupation = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        MothersOccupation = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        MaritarialStatus = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        RegDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.StudentAttendences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOrYearId = c.String(maxLength: 128),
                        TotalStudent = c.Int(nullable: false),
                        FemaleStudentNo = c.Int(nullable: false),
                        TotalPresentStudent = c.Int(nullable: false),
                        PresentFemaleStudent = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassOrYears", t => t.ClassOrYearId)
                .Index(t => t.ClassOrYearId);
            
            CreateTable(
                "dbo.CommitteeCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MemberNo = c.String(nullable: false),
                        Description = c.String(),
                        Established = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommitteeDesignations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CommitteeCatagoryId = c.Int(nullable: false),
                        MemberNo = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommitteeCatagories", t => t.CommitteeCatagoryId, cascadeDelete: true)
                .Index(t => t.CommitteeCatagoryId);
            
            CreateTable(
                "dbo.CommitteeMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthRegNo = c.Int(nullable: false),
                        CommitteeCatagoryId = c.Int(nullable: false),
                        CommitteeDesignationId = c.Int(nullable: false),
                        AppointedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTeacherAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthRegNo = c.String(),
                        SubjectId = c.String(),
                        ClassOrYearId = c.String(),
                        YearOfExam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false),
                        DivisionId = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.PoliceStations",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false),
                        DistrictId = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.PostOffices",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        PostCode = c.String(nullable: false, maxLength: 4),
                        Name = c.String(nullable: false),
                        PoliceStationId = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.PoliceStations", t => t.PoliceStationId, cascadeDelete: true)
                .Index(t => t.PoliceStationId);
            
            CreateTable(
                "dbo.VillageRoads",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 6),
                        Name = c.String(nullable: false),
                        PostOfficeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.PostOffices", t => t.PostOfficeId, cascadeDelete: true)
                .Index(t => t.PostOfficeId);
            
            CreateTable(
                "dbo.UnionOrWords",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false),
                        PoliceStationId = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.PoliceStations", t => t.PoliceStationId, cascadeDelete: true)
                .Index(t => t.PoliceStationId);
            
            CreateTable(
                "dbo.EducationBoards",
                c => new
                    {
                        BoardCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BoardCode);
            
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        EducationLevelCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EducationLevelCode);
            
            CreateTable(
                "dbo.EmployeeEducationalQualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirtgRegNo = c.String(nullable: false),
                        EducationLevelId = c.String(nullable: false, maxLength: 128),
                        ExamOrDegreeId = c.String(nullable: false),
                        BoardOrUniversity = c.String(nullable: false),
                        MajorSubjectId = c.String(nullable: false),
                        InstituteName = c.String(nullable: false),
                        CourseDuration = c.String(),
                        PassingYear = c.String(nullable: false),
                        GpaOrDivison = c.String(nullable: false),
                        RegNumber = c.String(),
                        RollNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelId, cascadeDelete: true)
                .Index(t => t.EducationLevelId);
            
            CreateTable(
                "dbo.ExamOrDegrees",
                c => new
                    {
                        ExamOrDegreeCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        EducationLevelId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ExamOrDegreeCode)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelId, cascadeDelete: true)
                .Index(t => t.EducationLevelId);
            
            CreateTable(
                "dbo.MajorSubjectOrGroups",
                c => new
                    {
                        MajorSubjectOrGroupCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ExamOrDegreeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MajorSubjectOrGroupCode)
                .ForeignKey("dbo.ExamOrDegrees", t => t.ExamOrDegreeId, cascadeDelete: true)
                .Index(t => t.ExamOrDegreeId);
            
            CreateTable(
                "dbo.ExamYears",
                c => new
                    {
                        ExamYearCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExamYearCode);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthReg = c.String(),
                        Name = c.String(),
                        Strength = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublicExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamOrDegreeId = c.String(),
                        ExamYear = c.Int(nullable: false),
                        TotalStudent = c.Int(nullable: false),
                        FemaleStudent = c.Int(nullable: false),
                        PassedStudent = c.Int(nullable: false),
                        FemalePassed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rmoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ShiftCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SectionCode)
                .ForeignKey("dbo.Sections", t => t.ShiftCode)
                .ForeignKey("dbo.Shifts", t => t.ShiftCode)
                .Index(t => t.ShiftCode);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftCode);
            
            CreateTable(
                "dbo.StudentEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthRegNo = c.String(),
                        ClassOrYearId = c.String(),
                        SubjectId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherAttendences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalTeacher = c.Int(nullable: false),
                        PresentTeacher = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingQualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NidOrBirthReg = c.String(),
                        ProviderName = c.String(),
                        RegistrationNo = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        StartFrom = c.DateTime(nullable: false),
                        Finished = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "ShiftCode", "dbo.Shifts");
            DropForeignKey("dbo.Sections", "ShiftCode", "dbo.Sections");
            DropForeignKey("dbo.MajorSubjectOrGroups", "ExamOrDegreeId", "dbo.ExamOrDegrees");
            DropForeignKey("dbo.ExamOrDegrees", "EducationLevelId", "dbo.EducationLevels");
            DropForeignKey("dbo.EmployeeEducationalQualifications", "EducationLevelId", "dbo.EducationLevels");
            DropForeignKey("dbo.UnionOrWords", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.VillageRoads", "PostOfficeId", "dbo.PostOffices");
            DropForeignKey("dbo.PostOffices", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.PoliceStations", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.CommitteeDesignations", "CommitteeCatagoryId", "dbo.CommitteeCatagories");
            DropForeignKey("dbo.StudentAttendences", "ClassOrYearId", "dbo.ClassOrYears");
            DropForeignKey("dbo.StudentApplications", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.GuardianAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.EmployeeAccounts", "SubjectCode", "dbo.Subjects");
            DropForeignKey("dbo.EmployeeAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.EmployeeAccounts", "EmployeeCatagoryId", "dbo.SecurityRoles");
            DropForeignKey("dbo.EmployeeAccounts", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.UserSecurityRoles", "RoleId", "dbo.SecurityRoles");
            DropForeignKey("dbo.EmployeeApplications", "SubjectCode", "dbo.Subjects");
            DropForeignKey("dbo.EmployeeApplications", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.StudentApplications", "StudentConfirmId", "dbo.ConfirmationCatagories");
            DropForeignKey("dbo.StudentAccounts", "StudentConfirmId", "dbo.ConfirmationCatagories");
            DropForeignKey("dbo.StudentAccounts", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.StudentAccounts", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.StudentAccounts", "ClassOrYearId", "dbo.ClassOrYears");
            DropForeignKey("dbo.EmployeeApplications", "ConfirmationId", "dbo.ConfirmationCatagories");
            DropForeignKey("dbo.EmployeeAccounts", "ConfirmationId", "dbo.ConfirmationCatagories");
            DropForeignKey("dbo.EmployeeApplications", "EmployeeCatagoryId", "dbo.SecurityRoles");
            DropForeignKey("dbo.EmployeeApplications", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Designations", "EmployeeCatagoryId", "dbo.SecurityRoles");
            DropForeignKey("dbo.Subjects", "CatagoryId", "dbo.SubjectCatagories");
            DropForeignKey("dbo.Subjects", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Subjects", "ClassId", "dbo.ClassOrYears");
            DropForeignKey("dbo.StudentApplications", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.StudentApplications", "ClassOrYearId", "dbo.ClassOrYears");
            DropIndex("dbo.Sections", new[] { "ShiftCode" });
            DropIndex("dbo.MajorSubjectOrGroups", new[] { "ExamOrDegreeId" });
            DropIndex("dbo.ExamOrDegrees", new[] { "EducationLevelId" });
            DropIndex("dbo.EmployeeEducationalQualifications", new[] { "EducationLevelId" });
            DropIndex("dbo.UnionOrWords", new[] { "PoliceStationId" });
            DropIndex("dbo.VillageRoads", new[] { "PostOfficeId" });
            DropIndex("dbo.PostOffices", new[] { "PoliceStationId" });
            DropIndex("dbo.PoliceStations", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropIndex("dbo.CommitteeDesignations", new[] { "CommitteeCatagoryId" });
            DropIndex("dbo.StudentAttendences", new[] { "ClassOrYearId" });
            DropIndex("dbo.GuardianAccounts", new[] { "OccupationId" });
            DropIndex("dbo.UserSecurityRoles", new[] { "RoleId" });
            DropIndex("dbo.StudentAccounts", new[] { "OccupationId" });
            DropIndex("dbo.StudentAccounts", new[] { "StudentConfirmId" });
            DropIndex("dbo.StudentAccounts", new[] { "GroupId" });
            DropIndex("dbo.StudentAccounts", new[] { "ClassOrYearId" });
            DropIndex("dbo.EmployeeApplications", new[] { "OccupationId" });
            DropIndex("dbo.EmployeeApplications", new[] { "ConfirmationId" });
            DropIndex("dbo.EmployeeApplications", new[] { "SubjectCode" });
            DropIndex("dbo.EmployeeApplications", new[] { "DesignationId" });
            DropIndex("dbo.EmployeeApplications", new[] { "EmployeeCatagoryId" });
            DropIndex("dbo.Designations", new[] { "EmployeeCatagoryId" });
            DropIndex("dbo.EmployeeAccounts", new[] { "OccupationId" });
            DropIndex("dbo.EmployeeAccounts", new[] { "ConfirmationId" });
            DropIndex("dbo.EmployeeAccounts", new[] { "SubjectCode" });
            DropIndex("dbo.EmployeeAccounts", new[] { "DesignationId" });
            DropIndex("dbo.EmployeeAccounts", new[] { "EmployeeCatagoryId" });
            DropIndex("dbo.Subjects", new[] { "CatagoryId" });
            DropIndex("dbo.Subjects", new[] { "GroupId" });
            DropIndex("dbo.Subjects", new[] { "ClassId" });
            DropIndex("dbo.StudentApplications", new[] { "OccupationId" });
            DropIndex("dbo.StudentApplications", new[] { "StudentConfirmId" });
            DropIndex("dbo.StudentApplications", new[] { "GroupId" });
            DropIndex("dbo.StudentApplications", new[] { "ClassOrYearId" });
            DropTable("dbo.TrainingQualifications");
            DropTable("dbo.TeacherAttendences");
            DropTable("dbo.StudentEnrollments");
            DropTable("dbo.Shifts");
            DropTable("dbo.Sections");
            DropTable("dbo.Rmoes");
            DropTable("dbo.PublicExamResults");
            DropTable("dbo.Experiences");
            DropTable("dbo.ExamYears");
            DropTable("dbo.MajorSubjectOrGroups");
            DropTable("dbo.ExamOrDegrees");
            DropTable("dbo.EmployeeEducationalQualifications");
            DropTable("dbo.EducationLevels");
            DropTable("dbo.EducationBoards");
            DropTable("dbo.UnionOrWords");
            DropTable("dbo.VillageRoads");
            DropTable("dbo.PostOffices");
            DropTable("dbo.PoliceStations");
            DropTable("dbo.Divisions");
            DropTable("dbo.Districts");
            DropTable("dbo.CourseTeacherAssigns");
            DropTable("dbo.CommitteeMembers");
            DropTable("dbo.CommitteeDesignations");
            DropTable("dbo.CommitteeCatagories");
            DropTable("dbo.StudentAttendences");
            DropTable("dbo.GuardianAccounts");
            DropTable("dbo.UserSecurityRoles");
            DropTable("dbo.StudentAccounts");
            DropTable("dbo.ConfirmationCatagories");
            DropTable("dbo.EmployeeApplications");
            DropTable("dbo.SecurityRoles");
            DropTable("dbo.Designations");
            DropTable("dbo.EmployeeAccounts");
            DropTable("dbo.Occupations");
            DropTable("dbo.SubjectCatagories");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.StudentApplications");
            DropTable("dbo.ClassOrYears");
            DropTable("dbo.BloodGroups");
            DropTable("dbo.Addresses");
            DropTable("dbo.AddressCatagories");
            DropTable("dbo.AcademicExamResults");
        }
    }
}
