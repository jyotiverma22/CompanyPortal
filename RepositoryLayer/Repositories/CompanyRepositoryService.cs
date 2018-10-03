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
        DataLayer datalayer = new DataLayer();

        public bool AddProjects(Project project)
        {
            return datalayer.AddProject(project);
        }

        public bool AddUsers(Registration registration)
        {
            return datalayer.AddUsers(registration);
        }

        public bool CheckEmailAddressStatus(string email)
        {
            return datalayer.CheckEmailAddressStatus(email);
        }

        public SessionModel CheckUser(Login login)
        {
            return datalayer.CheckUser(login);
        }

        public bool CheckUsernameStatus(string username)
        {
            return datalayer.CheckUsernameStatus(username);
        }

        public IEnumerable<string> getAllProjectManagers()
        {
            return datalayer.getAllProjectManagers();
        }

        public List<BloodGroup> GetBloodGroups()
        {
            return datalayer.GetBloodGroups();
        }

        public EmployeesDetails GetEmployeesDetails(string username)
        {
            return datalayer.GetEmloyeesDetails(username);
        }


        // Get all project details
        public IEnumerable<Project> GetProjectDetail(string username,string status)
        {
            return datalayer.GetProjectDetails(username,status);
        }

        public IEnumerable<Registration> getTeamDetails(int pid)
        {
            return datalayer.getTeamDetails(pid);
        }

        public string GetUserId()
        {
            return datalayer.GetUserId();
        }

        public bool SaveErrorLoggingDetails(DbLogging dbLogging)
        {
            return datalayer.SaveErrorLoggingDetails(dbLogging);
        }
    }
}
