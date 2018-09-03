using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DbContexts
{
    class CompanyDbContext :DbContext
    {
        public CompanyDbContext():base(GetOptions(ConfigurationManager.ConnectionStrings["CompanyDbContext"].ConnectionString))
        {

        }

        private static DbContextOptions GetOptions(String str)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), str).Options;
        }


        public DbSet<Registration> UserRegistration { get; set; }
    }
}
