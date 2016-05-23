using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using StartupInstitute.Models;

namespace StartupInstitute.Security
{
    public class UserSecurityRole
    {
        [Key]
        public string UserRoleId { get; set; }
        public string UserAccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NidOrBirthRegNo { get; set; }
        public string EmailAddess { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleId { get; set; }
    }
}