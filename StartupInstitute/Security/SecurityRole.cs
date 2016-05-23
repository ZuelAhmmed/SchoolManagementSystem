using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StartupInstitute.Models;

namespace StartupInstitute.Security
{
    public class SecurityRole
    {
        [Key]
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<Designation> Designations { get; set; }
        public virtual ICollection<EmployeeApplication> EmployeeApplications { get; set; }
        public virtual ICollection<EmployeeAccount> EmployeeAccounts { get; set; }
    }
}