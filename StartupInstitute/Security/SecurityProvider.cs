using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using StartupInstitute.Models.DbModels;

namespace StartupInstitute.Security
{
    public class SecurityProvider : MembershipProvider
    {
        private InstituteDbContext db = new InstituteDbContext();
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUserNameExisis(string username)
        {
            var student = db.StudentAccounts.Where(u => u.UserName == username).FirstOrDefault();
            var studentApp = db.StudentApplications.Where(u => u.UserName == username).FirstOrDefault();
            var employee = db.EmployeeAccounts.Where(u => u.UserName == username).FirstOrDefault();
            var employeeApp = db.EmployeeApplications.Where(u => u.UserName == username).FirstOrDefault();
            if (student != null || studentApp != null || employee != null || employeeApp != null)
            {
                return true;
            }
            return false;
        }

        public bool IsNidOrBirthRegNoExisi(string nidOrBirthRegNo)
        {
            var student = db.StudentAccounts.Where(u => u.NidOrBirtgRegNo == nidOrBirthRegNo).FirstOrDefault();
            var studentApp = db.StudentApplications.Where(u => u.NidOrBirtgRegNo == nidOrBirthRegNo).FirstOrDefault();
            var employee = db.EmployeeAccounts.Where(u => u.NidOrBirtgRegNo == nidOrBirthRegNo).FirstOrDefault();
            var employeeApp = db.EmployeeApplications.Where(u => u.NidOrBirtgRegNo == nidOrBirthRegNo).FirstOrDefault();
            if (student != null || studentApp != null || employee != null || employeeApp != null)
            {
                return true;
            }
            return false;
        }

        public bool IsEmailExist(string emailAddress)
        {
            var student = db.StudentAccounts.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            var studentApp = db.StudentApplications.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            var employee = db.EmployeeAccounts.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            var employeeApp = db.EmployeeApplications.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            if (student != null || studentApp != null || employee != null || employeeApp != null)
            {
                return true;
            }
            return false;
        }

        public bool IsUserSecurityRoleExist(UserSecurityRole userSecurityRole)
        {
            UserSecurityRole role =
                db.UserSecurityRoles.Where(
                    ur => ur.NidOrBirthRegNo == userSecurityRole.NidOrBirthRegNo && ur.RoleId == userSecurityRole.RoleId)
                    .FirstOrDefault();
            if (role != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user =
                db.UserSecurityRoles.Where(
                    u =>
                        (u.UserName == username || u.NidOrBirthRegNo == username) && u.Password == password)
                    .FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}