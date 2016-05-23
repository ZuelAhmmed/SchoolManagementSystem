using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace StartupInstitute.Security
{
    public class SecurityPrinciple : IPrincipal
    {
        private readonly SecurityIdentity identity;

        public SecurityPrinciple(SecurityIdentity identity)
        {
            this.identity = identity;
        }


        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }
    }
}