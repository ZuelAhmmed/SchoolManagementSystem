﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StartupInstitute.Models
{
    public class StudentAccount : BasicAccount
    {
        [Required(ErrorMessage = "Select Class")]
        public string ClassOrYearId { get; set; }

        public int ClassRollNo { get; set; }

        [Required(ErrorMessage = "Type Fathers/Mothers National ID Number")]
        public string GuardianNid { get; set; }

        [Required(ErrorMessage = "Select Your Group.")]
        public string GroupId { get; set; }

        [Required(ErrorMessage = "Select Shift")]
        public string Shift  { get; set; }

        [Required(ErrorMessage = "Select Section")]
        public string Section { get; set; }

        [DisplayName("Yearly Family Income")]
        [Required(ErrorMessage = "Type Family Income")]
        public int FamilyIncome { get; set; }

        // Usable By The Administrator
        public string StudentConfirmId { get; set; }

        public DateTime ConfirmDate { get; set; }

        public string ConfirmedBy { get; set; }

        public string ExamPermissionId { get; set; }

        public DateTime PassingYear { get; set; }




        [ForeignKey("ClassOrYearId")]
        public virtual ClassOrYear ClassOrYears { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Gorups { get; set; }
        [ForeignKey("StudentConfirmId")]
        public virtual ConfirmationCatagory StudentConfirm { get; set; }
        //[ForeignKey("ExamPermissionId")]
        //public virtual ConfirmationCatagory ExamPermission { get; set; }


    }
}