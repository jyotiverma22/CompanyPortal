using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DbContexts
{
   public static class DataLayer
    {
        public static bool  AddUsers(Registration registration)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                if (companyDbContext.AddUsers(registration))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool CheckEmailAddressStatus(string email)
                {
            using (CompanyDbContext companyDbContext2 = new CompanyDbContext())
            {
                if (companyDbContext2.CheckEmailAddressStatus(email))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool CheckUsernameStatus(string username)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                if (companyDbContext.CheckUsernameStatus(username))
                {
                    return true;
                }
                return false;
            }
            
        }

        public static string GetUserId()
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                return companyDbContext.GetUserId();
            }
        }

        public static List<BloodGroup> GetBloodGroups()
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                return companyDbContext.getBloodGroupList();
            }
        }

        public static bool CheckUser(Login login)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                return companyDbContext.UserCheck(login);
            }
        }

        public static EmployeesDetails GetEmloyeesDetails(string username)
        {
            using (CompanyDbContext companyDbContext=new CompanyDbContext())
            {
                return companyDbContext.GetEmployeesDetails(username);
            }
        }


    }
}
