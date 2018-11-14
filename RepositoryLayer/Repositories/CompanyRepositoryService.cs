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

        public int AddProjects(Project project)
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

        public bool DeleteProject(int pid,string userid)
        {
            return datalayer.DeleteProject(pid,userid);
        }

        public IEnumerable<string> getAllProjectManagers()
        {
            return datalayer.getAllProjectManagers();
        }

        public List<string> GetAllTechnologies()
        {
            return datalayer.GetAllTechnologies();
        }

        public List<Attendence> GetAttendence(string UserId)
        {
            return datalayer.GetAttendence(UserId);
        }

        public List<BloodGroup> GetBloodGroups()
        {
            return datalayer.GetBloodGroups();
        }

        public List<Employee> GetEmployeeDetails()
        {
            return datalayer.GetEmployeeDetails();
        }

        public EmployeesDetails GetEmloyeesDetailsOnLogin(string username)
        {
            return datalayer.GetEmloyeesDetailsOnLogin(username);
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

        public List<string> GetTechnologyUserId(string tech)
        {
            return datalayer.GetTechnologyUserId(tech);
        }

        public string GetUserId()
        {
            return datalayer.GetUserId();
        }

        public bool SaveErrorLoggingDetails(DbLogging dbLogging)
        {
            return datalayer.SaveErrorLoggingDetails(dbLogging);
        }

        public void SetAllEmployeesAttendence()
        {
            datalayer.SetAllEmployeesAttendence();
        }

        public Project ShowParticularProjectdetails(int Pid)
        {
            return datalayer.ShowParticularProjectDetails(Pid);
        }

        public bool UpdateAttendence(Attendence attendence)
        {
            return datalayer.UpdateAttendence(attendence);
         
        }

        public bool UpdateProject(Project project)
        {
            return datalayer.UpdateProject(project);
        }

        public List<string> GetListInDropDown(string col)
        {
            return datalayer.GetListInDropDown(col);
        }
    }
}
