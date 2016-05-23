using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI.WebControls;
using StartupInstitute.Models;
using StartupInstitute.Models.DbModels;
using StartupInstitute.PrimaryModels;
using StartupInstitute.ViewModels;

namespace StartupInstitute.Security
{
    public class SecurityManager
    {
        private SecurityProvider securityProvider = new SecurityProvider();
        private InstituteDbContext db = new InstituteDbContext();

        public HttpCookie SignIn(LoginViewModel login)
        {
            bool isValidUser = false;
            HttpCookie authCookie = null;

            if ((login.UserName != String.Empty || login.NidOrBirthRegNo != String.Empty) && login.Password != String.Empty)
            {
                isValidUser = Membership.ValidateUser(login.UserName, login.Password);
                if (isValidUser)
                {
                    UserSecurityRole user =
                        db.UserSecurityRoles.Where(u => (u.UserName == login.UserName || u.NidOrBirthRegNo == login.NidOrBirthRegNo) && u.Password == login.Password)
                            .FirstOrDefault();
                    if (user != null)
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string data = js.Serialize(user);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, login.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), login.RememberMe, data);
                        string encToken = FormsAuthentication.Encrypt(ticket);
                        authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                    }
                }
            }

            return authCookie;
        }

        public int SugnOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool SignUp(EmployeeApplication employeeApplication)
        {
            if (employeeApplication != null)
            {
                if (!securityProvider.IsNidOrBirthRegNoExisi(employeeApplication.NidOrBirtgRegNo))
                {
                    if (!securityProvider.IsUserNameExisis(employeeApplication.UserName))
                    {
                        if (!securityProvider.IsEmailExist(employeeApplication.EmailAddress))
                        {
                            employeeApplication.AccountId = CreateGuid();
                            db.EmployeeApplications.Add(employeeApplication);
                            db.SaveChanges();
                        }
                    }
                }
            }
            return false;
        }
        public bool SignUp(EmployeeAccount employeeAccount)
        {
            if (employeeAccount != null)
            {
                if (!securityProvider.IsNidOrBirthRegNoExisi(employeeAccount.NidOrBirtgRegNo))
                {
                    if (!securityProvider.IsUserNameExisis(employeeAccount.UserName))
                    {
                        if (!securityProvider.IsEmailExist(employeeAccount.EmailAddress))
                        {
                            employeeAccount.AccountId = CreateGuid();
                            employeeAccount.ConfirmationId = CatConfirmation.Yes;

                            db.EmployeeAccounts.Add(employeeAccount);
                            db.SaveChanges();

                            
                            if (db.EmployeeAccounts.Count() == 1)
                            {
                                UserSecurityRole userRole = new UserSecurityRole();
                                userRole.UserAccountId = employeeAccount.AccountId;
                                userRole.UserName = employeeAccount.UserName;
                                userRole.Password = employeeAccount.Password;
                                userRole.NidOrBirthRegNo = employeeAccount.NidOrBirtgRegNo;
                                userRole.EmailAddess = employeeAccount.EmailAddress;
                                userRole.FirstName = employeeAccount.FirstName;
                                userRole.LastName = employeeAccount.LasttName;
                                userRole.RoleId =
                                    (db.SecurityRoles.Where(r => r.RoleName == SecurityRoles.Admin).FirstOrDefault())
                                        .RoleId;

                                if (!securityProvider.IsUserSecurityRoleExist(userRole))
                                {
                                    UserSecurityRole adminRole = new UserSecurityRole();
                                    adminRole = userRole;
                                    adminRole.UserRoleId = CreateGuid();
                                    db.UserSecurityRoles.Add(userRole);
                                    db.SaveChanges();
                                }
                            }

                            foreach (string role in SecurityRoles.GetRoleList())
                            {
                                SecurityRole securityRole = db.SecurityRoles.Where(r => r.RoleName == role).FirstOrDefault();
                                if (employeeAccount.EmployeeCatagoryId == securityRole.RoleId)
                                {
                                    UserSecurityRole employeeUserSecurityRoleRole = new UserSecurityRole();
                                    employeeUserSecurityRoleRole.UserRoleId = CreateGuid();
                                    employeeUserSecurityRoleRole.UserAccountId = employeeAccount.AccountId;
                                    employeeUserSecurityRoleRole.UserName = employeeAccount.UserName;
                                    employeeUserSecurityRoleRole.Password = employeeAccount.Password;
                                    employeeUserSecurityRoleRole.NidOrBirthRegNo = employeeAccount.NidOrBirtgRegNo;
                                    employeeUserSecurityRoleRole.EmailAddess = employeeAccount.EmailAddress;
                                    employeeUserSecurityRoleRole.FirstName = employeeAccount.FirstName;
                                    employeeUserSecurityRoleRole.LastName = employeeAccount.LasttName;
                                    employeeUserSecurityRoleRole.RoleId =
                                (db.SecurityRoles.Where(r => r.RoleName == role).FirstOrDefault())
                                    .RoleId;

                                    if (!securityProvider.IsUserSecurityRoleExist(employeeUserSecurityRoleRole))
                                    {
                                        db.UserSecurityRoles.Add(employeeUserSecurityRoleRole);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool SignUp(StudentApplication studentApplication)
        {
            if (studentApplication != null)
            {
                if (!securityProvider.IsNidOrBirthRegNoExisi(studentApplication.NidOrBirtgRegNo))
                {
                    if (!securityProvider.IsUserNameExisis(studentApplication.UserName))
                    {
                        if (!securityProvider.IsEmailExist(studentApplication.EmailAddress))
                        {
                            studentApplication.AccountId = CreateGuid();
                            db.StudentApplications.Add(studentApplication);
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool SignUp(StudentAccount studentAccount)
        {
            if (studentAccount != null)
            {
                if (!securityProvider.IsNidOrBirthRegNoExisi(studentAccount.NidOrBirtgRegNo))
                {
                    if (!securityProvider.IsUserNameExisis(studentAccount.UserName))
                    {
                        if (!securityProvider.IsEmailExist(studentAccount.EmailAddress))
                        {
                            studentAccount.AccountId = CreateGuid();
                            studentAccount.StudentConfirmId = CatConfirmation.Yes;

                            db.StudentAccounts.Add(studentAccount);
                            db.SaveChanges();

                            UserSecurityRole userRole = new UserSecurityRole();
                            userRole.UserRoleId = CreateGuid();
                            userRole.UserAccountId = studentAccount.AccountId;
                            userRole.UserName = studentAccount.UserName;
                            userRole.Password = studentAccount.Password;
                            userRole.NidOrBirthRegNo = studentAccount.NidOrBirtgRegNo;
                            userRole.EmailAddess = studentAccount.EmailAddress;
                            userRole.FirstName = studentAccount.FirstName;
                            userRole.LastName = studentAccount.LasttName;

                            userRole.RoleId =
                                (db.SecurityRoles.Where(r => r.RoleName == SecurityRoles.Student).FirstOrDefault())
                                    .RoleId;

                            if (!securityProvider.IsUserSecurityRoleExist(userRole))
                            {
                                db.UserSecurityRoles.Add(userRole);
                                db.SaveChanges();
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool SignUp(GuardianAccount guardianAccount)
        {
            if (guardianAccount != null)
            {
                if (!securityProvider.IsNidOrBirthRegNoExisi(guardianAccount.NidOrBirtgRegNo))
                {
                    if (!securityProvider.IsUserNameExisis(guardianAccount.UserName))
                    {
                        if (!securityProvider.IsEmailExist(guardianAccount.EmailAddress))
                        {
                            guardianAccount.AccountId = CreateGuid();
                            db.GurdianAccounts.Add(guardianAccount);
                            db.SaveChanges();

                            UserSecurityRole userRole = new UserSecurityRole();
                            userRole.UserRoleId = CreateGuid();
                            userRole.UserAccountId = guardianAccount.AccountId;
                            userRole.UserName = guardianAccount.UserName;
                            userRole.Password = guardianAccount.Password;
                            userRole.NidOrBirthRegNo = guardianAccount.NidOrBirtgRegNo;
                            userRole.FirstName = guardianAccount.FirstName;
                            userRole.LastName = guardianAccount.LasttName;

                            userRole.RoleId =
                                (db.SecurityRoles.Where(r => r.RoleName == SecurityRoles.Guardian).FirstOrDefault())
                                    .RoleId;
                            
                            if (!securityProvider.IsUserSecurityRoleExist(userRole))
                            {
                                db.UserSecurityRoles.Add(userRole);
                                db.SaveChanges();
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string CreateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}