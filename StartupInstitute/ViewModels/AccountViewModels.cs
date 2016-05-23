using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartupInstitute.ViewModels
{
    public class StuentAdmissionViewModel
    {

    }

    public class LoginViewModel
    {
        public string NidOrBirthRegNo { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }

    public class ForgotPasswordViewModel
    {
        
    }
}