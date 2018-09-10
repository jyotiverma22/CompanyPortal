using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.DbContexts;
using Models;

namespace RepositoryLayer.Repositories
{
    public class CompanyRepositoryService : ICompanyRepository
    {

        public bool AddUsers(Registration registration)
        {
            return DataLayer.AddUsers(registration);
        }

        public bool CheckEmailAddressStatus(string email)
        {
            return DataLayer.CheckEmailAddressStatus(email);
        }

        public bool CheckUser(Login login)
        {
            return DataLayer.CheckUser(login);
        }

        public bool CheckUsernameStatus(string username)
        {
            return DataLayer.CheckUsernameStatus(username);
        }

        public List<BloodGroup> GetBloodGroups()
        {
            return DataLayer.GetBloodGroups();
        }

        public EmployeesDetails GetEmployeesDetails(string username)
        {
            return DataLayer.GetEmloyeesDetails(username);
        }

        public string GetUserId()
        {
            return DataLayer.GetUserId();
        }
    }
}
