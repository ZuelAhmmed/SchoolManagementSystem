using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace StartupInstitute.Models
{
    //Educational Qualification Models Starts
    public class EducationLevel
    {
        [Key]
        public string EducationLevelCode { get; set; }

        [DisplayName("Exam Level")]
        [Required(ErrorMessage = "Type Exam Level Name.")]
        public string Name { get; set; }

        public virtual ICollection<ExamOrDegree> ExamOrDegrees { get; set; }
        public virtual ICollection<EmployeeEducationalQualification> EducationalQualifications { get; set; }
    }

    public class ExamOrDegree
    {
        [Key]
        public string ExamOrDegreeCode { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Type Exam Name.")]
        public string Name { get; set; }

        [DisplayName("Education Level")]
        [Required(ErrorMessage = "Select Exam Level.")]
        public string EducationLevelId { get; set; }

        [ForeignKey("EducationLevelId")]
        public virtual EducationLevel EducationLevel { get; set; }

        public virtual ICollection<MajorSubjectOrGroup> MajorSubjectOrGroups { get; set; }
    }

    public class MajorSubjectOrGroup
    {
        [Key]
        public string MajorSubjectOrGroupCode { get; set; }

        [DisplayName("Subject/Group")]
        [Required(ErrorMessage = "Type Major Subject/Group.")]
        public string Name { get; set; }

        [DisplayName("Exam/Degree")]
        [Required(ErrorMessage = "Select Exam/Degree.")]
        public string ExamOrDegreeId { get; set; }

        [ForeignKey("ExamOrDegreeId")]
        public virtual ExamOrDegree ExamOrDegree { get; set; }
    }

    public class EmployeeEducationalQualification
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "Select User Name")]
        public string NidOrBirtgRegNo { get; set; }

        [DisplayName("Education Level")]
        [Required(ErrorMessage = "Select Education Level")]
        public string EducationLevelId { get; set; }

        [DisplayName("Exam/Degree")]
        [Required(ErrorMessage = "Select Exam/Degree")]
        public string ExamOrDegreeId { get; set; }

        [DisplayName("Board/University")]
        [Required(ErrorMessage = "Select Board/University")]
        public string BoardOrUniversity { get; set; }

        [DisplayName("Major Subject/Group")]
        [Required(ErrorMessage = "Select Major Subject/Group")]
        public string MajorSubjectId { get; set; }

        [DisplayName("Institute Name")]
        [Required(ErrorMessage = "Type Institute Name.")]
        public string InstituteName { get; set; }

        [DisplayName("Course Duration")]
        public string CourseDuration { get; set; }

        [DisplayName("Passing Year")]
        [Required(ErrorMessage = "Type Passing Year")]
        public string PassingYear { get; set; }

        [DisplayName("Result")]
        [Required(ErrorMessage = "Type Result, Like : 5.00, 1st Divison")]
        public string GpaOrDivison { get; set; }

        [ForeignKey("EducationLevelId")]
        public virtual EducationLevel EducationLevel { get; set; }

    }

    public class StudentEmployeeEducationalQualification : EmployeeEducationalQualification
    {
        [Required(ErrorMessage = "Type Exam Registration Number")]
        public string RegNumber { get; set; }

        [Required(ErrorMessage = "Type Exam Roll Number")]
        public string RollNumber { get; set; }
    }

    //Educational Qualification Models Finished

    public class TrainingQualification
    {
        public int Id { get; set; }
        public string NidOrBirthReg { get; set; }
        public string ProviderName { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime Finished { get; set; }
    }

    public class Experience
    {
        public int Id { get; set; }
        public string NidOrBirthReg { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string Description { get; set; }
    }
}