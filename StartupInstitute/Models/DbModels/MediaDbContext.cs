using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StartupInstitute.Models.DbModels
{
    public class MediaDbContext : DbContext
    {
        public MediaDbContext() :base("MediaDbConnection")
        {
            
        }

        public DbSet<Image> Images { get; set; }

        public static MediaDbContext Create()
        {
            return new MediaDbContext();
        }
    }
}