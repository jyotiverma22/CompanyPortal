﻿using Models;
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

        EmployeesDetails GetEmloyeesDetailsOnLogin(string username);

        IEnumerable<Project> GetProjectDetail(string username,string status);

        IEnumerable<Registration> getTeamDetails(int pid);

        bool SaveErrorLoggingDetails(DbLogging dbLogging);

        IEnumerable<string> getAllProjectManagers();

        int AddProjects(Project project);

        List<String> GetAllTechnologies();

        List<String> GetTechnologyUserId(string tech);

        Project ShowParticularProjectdetails(int Pid);

        bool UpdateProject(Project project);

        bool DeleteProject(int pid,string userid);

        bool UpdateAttendence(Attendence attendence);

        void SetAllEmployeesAttendence();

        List<Attendence> GetAttendence(string UserId);

        List<Employee> GetEmployeeDetails();

        List<string> GetListInDropDown(string col);
    }
}
