using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace StartupInstitute.Security
{
    public class SecurityIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public UserSecurityRole User { get; set; }

        public SecurityIdentity(UserSecurityRole user)
        {
            Identity = new GenericIdentity(user.UserName);
            User = user;
        }

        string IIdentity.AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        bool IIdentity.IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        string IIdentity.Name
        {
            get { return Identity.Name; }
        }
    }
}