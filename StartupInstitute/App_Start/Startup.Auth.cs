using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using StartupInstitute.Models.DbModels;
using StartupInstitute.Security;

namespace StartupInstitute
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(InstituteDbContext.Create);
            app.CreatePerOwinContext(MediaDbContext.Create);
            PrimaryDataManager primaryData = new PrimaryDataManager();
            primaryData.CreatePrimaryData();
        }
    }
}