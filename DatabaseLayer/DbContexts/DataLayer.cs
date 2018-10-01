using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DbContexts
{
   public class DataLayer
    {
        /// <summary>
        /// register the users and add the details into the database
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool  AddUsers(Registration registration)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                registration.DId = 5;
                registration.RId = 4;
                registration.R_M_Id = "CMP-1001";
                registration.Password = Password.EncodePassword(registration.Password, registration.Username);
                companyDbContext.UserRegistration.Add(registration);
                companyDbContext.SaveChanges();
                return true;
               
            }
        }

        /// <summary>
        /// check email Address if already exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmailAddressStatus(string email)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                var user = companyDbContext. UserRegistration.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// check username if already exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckUsernameStatus(string username)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                var user = companyDbContext.UserRegistration.Where(x => x.Username == username).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                return false; ;
            }
            
        }

        /// <summary>
        /// get the unique user id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                var users = companyDbContext.UserRegistration.Count(); ;
                if (users == 0)
                {
                    return "CMP-1001";
                }
                else
                {
                    Registration registration = companyDbContext.UserRegistration.OrderByDescending(x => x.Sno).First();

                    Console.WriteLine(registration);

                    string userid = registration.UserId;
                    userid = userid.Replace('"', ' ').Trim();
                    string[] id = userid.Split('-');
                    id[1] = (Int32.Parse(id[1]) + 1).ToString();
                    userid = id[0] + "-" + id[1];
                    return userid;

                }
            }
        }

        //returns the list of blood group
        public List<BloodGroup> GetBloodGroups()
        {
            
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                return companyDbContext.BloodGroups.ToList();
            }
        }


        /// <summary>
        /// to check user exist or not on login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public SessionModel CheckUser(Login login)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                //   login.Password = Password.EncodePassword(login.Password,login.Username);

                Registration user = companyDbContext. UserRegistration.Where(x => (x.Username == login.Username || x.Email == login.Username)).FirstOrDefault();
                if (user != null)
                {
                    login.Password = Password.EncodePassword(login.Password, user.Username);
                    if (user.Password == login.Password)
                    {
                        //                    string p = user.role.RoleName;
                        SessionModel m = companyDbContext. UserRegistration.Where(x => (x.Username == login.Username || x.Email == login.Username)).Select(c => new SessionModel { firstname = c.Firstname, rolename = c.role.RoleName, deptname = c.department.Dname, userid = c.UserId }).FirstOrDefault();
                        return m; ;
                    }

                    return null;
                }
                return null;

            }
        }

        /// <summary>
        /// return the employees details 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public EmployeesDetails GetEmloyeesDetails(string username)
        {
            using (CompanyDbContext companyDbContext=new CompanyDbContext())
            {
                EmployeesDetails employees = new EmployeesDetails();
                employees =companyDbContext.UserRegistration.Where(x => (x.Username == username || x.Email == username || x.UserId==username)).Select(c => new EmployeesDetails { userId = c.UserId, Username = c.Username, FullName = (c.Firstname + " " + c.Lastname), DOB = c.DOB, Email = c.Email, Phone = c.Phone, Gender = c.Gender, Bloodgroup = c.bloodGroup.BloodGroupName, Department_name = c.department.Dname, Role_name = c.role.RoleName, Rep_Manager = (companyDbContext. UserRegistration.Where(m => m.UserId == (companyDbContext.Emp_Reportings.Where(u => u.Emp_ID == c.UserId).Select(u => u.Rep_Mgr).FirstOrDefault())).Select(m => m.Username).FirstOrDefault()) }).FirstOrDefault();
                //   Department d = Departments.Where(x => x.DId == reg.DId).FirstOrDefault();
                //   employees.userId = reg.UserId;
                return employees;
            }
        }

        // Get project details to set in jq grid
        public IEnumerable<Project> GetProjectDetails(string username,string status)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                List<Project> projs = new List<Project>();
                if (username == null)
                {
                    return companyDbContext.Projects.ToList();
                }
                else
                {
                    IQueryable<int> query =companyDbContext.Project_Teams.Where(t => t.Team_Id == (companyDbContext. UserRegistration.Where(r => (r.Username == username || r.Email == username)).Select(r => r.UserId).FirstOrDefault())).Select(p => p.PId);
                    foreach (int pid in query)
                    {
                        //&& c.Status=="status"
                        projs.AddRange(companyDbContext.Projects.Where(c => (c.PID == pid && c.Status==status)));
                    }

                    return projs;
                }
            }
        }

        /// <summary>
        /// get details of employees on particular project
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IEnumerable<Registration> getTeamDetails(int pid)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                List<Registration> reg = new List<Registration>();

                IQueryable<string> emps = companyDbContext.Project_Teams.Where(c => c.PId == pid).Select(c => c.Team_Id);

                foreach(var e in emps)
                {
                    reg.AddRange(companyDbContext.UserRegistration.Where(c => c.UserId == e));
                }
                return reg;
            }
        }


        public bool SaveErrorLoggingDetails(DbLogging dbLogging)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                if(dbLogging!=null)
                {
                    companyDbContext.Add(dbLogging);
                    companyDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
                
        }


        public IEnumerable<string> getAllProjectManagers()
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
              
              var  P_mgrs_Id = (from p in companyDbContext.UserRegistration
                             join r in companyDbContext.Roles on p.RId equals r.RID
                             where( r.Active == "true" && r.RoleName=="P_Manager")
                             select(p.UserId)).ToList();
                
                return P_mgrs_Id;
            }
        }

        public bool AddProject(Project project)
        {
            using (CompanyDbContext companyDbContext = new CompanyDbContext())
            {
                if (project != null)
                {
                    companyDbContext.Projects.Add(project);
                    companyDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }



    }
}
