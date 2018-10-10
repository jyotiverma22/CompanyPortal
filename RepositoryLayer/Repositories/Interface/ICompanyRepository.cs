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

        SessionModel CheckUser(Login login);

        EmployeesDetails GetEmployeesDetails(string username);

        IEnumerable<Project> GetProjectDetail(string username,string status);

        IEnumerable<Registration> getTeamDetails(int pid);

        bool SaveErrorLoggingDetails(DbLogging dbLogging);

        IEnumerable<string> getAllProjectManagers();

        int AddProjects(Project project);

        List<String> GetAllTechnologies();

        List<String> GetTechnologyUserId(string tech);
    }
}
