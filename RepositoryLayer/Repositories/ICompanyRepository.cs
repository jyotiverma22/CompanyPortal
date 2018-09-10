using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
   public interface ICompanyRepository
    {
        string GetUserId();

        bool AddUsers(Registration registration);

        bool CheckUsernameStatus(string username);

        bool CheckEmailAddressStatus(string email);

        List<BloodGroup> GetBloodGroups();

        bool CheckUser(Login login);

        EmployeesDetails GetEmployeesDetails(string username);
    }
}
