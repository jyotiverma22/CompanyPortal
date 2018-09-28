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
   public class CompanyDbContext :DbContext
    {
        public CompanyDbContext():base(GetOptions(ConfigurationManager.ConnectionStrings["CompanyDbContext"].ConnectionString))
        {

        }
        /// <summary>
        /// convert the connection string into the dbcontext options
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static DbContextOptions GetOptions(String str)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), str).Options;
        }


        public DbSet<Registration> UserRegistration { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Attendence> Emp_Attendence{ get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_Team> Project_Teams { get; set; }
        public DbSet<Emp_Reporting> Emp_Reportings { get; set; }
        public DbSet<DbLogging> DbLoggings { get; set; }

      

       
     

      

     

    }
}
