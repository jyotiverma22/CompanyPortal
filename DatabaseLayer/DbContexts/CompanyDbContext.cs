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


        public string GetUserId()
        {
             var users = UserRegistration.Count(); ;
            if (users == 0)
            {
                return "CMP-1001";
            }
            else
            {
                Registration registration = UserRegistration.OrderByDescending(x => x.Sno).First();

                Console.WriteLine(registration);

                string userid = registration.UserId;
                userid = userid.Replace('"', ' ').Trim();
                string[] id = userid.Split('-');
                id[1] = (Int32.Parse(id[1]) + 1).ToString();
                userid = id[0] +"-"+id[1];
                return userid;

            }
        }


        public bool AddUsers(Registration registration)
        {
            registration.DId = 5;
            registration.RId = 4;
            registration.Password= Password.EncodePassword(registration.Password,registration.Username);
            UserRegistration.Add(registration);
            SaveChanges();
            return true;
        }

        public bool CheckUsernameStatus(string username)
            {
            var user=UserRegistration.Where(x => x.Username == username).FirstOrDefault();
            if(user!=null)
            {
                return true;
            }
            return false;
        }


        public bool CheckEmailAddressStatus(string email)
        {
            var user = UserRegistration.Where(x => x.Email == email).FirstOrDefault();
            if(user!=null)
            {
                return true;
            }
            return false;
        }


        public List<BloodGroup> getBloodGroupList()
        {
            return BloodGroups.ToList();
        }


        public SessionModel UserCheck(Login login)
        {
         //   login.Password = Password.EncodePassword(login.Password,login.Username);

            Registration user = UserRegistration.Where(x =>   (x.Username==login.Username||x.Email==login.Username)).FirstOrDefault();
            if(user!=null)
            {
                login.Password = Password.EncodePassword(login.Password, user.Username);
                if(user.Password==login.Password)
                {
                    //                    string p = user.role.RoleName;
                    SessionModel m = UserRegistration.Where(x => (x.Username == login.Username || x.Email == login.Username)).Select(c => new SessionModel { firstname = c.Firstname, rolename = c.role.RoleName, deptname = c.department.Dname }).FirstOrDefault();
                    return m; ;
                }

                return null;
            }
            return null;
        }

        public EmployeesDetails GetEmployeesDetails(string username)
        {
            EmployeesDetails employees = new EmployeesDetails();
            employees = UserRegistration.Where(x => (x.Username == username || x.Email == username)).Select(c=>new EmployeesDetails { userId=c.UserId,Username=c.Username,FullName=(c.Firstname+" "+c.Lastname),DOB=c.DOB,Email=c.Email,Phone=c.Phone,Gender=c.Gender,Bloodgroup=c.bloodGroup.BloodGroupName,Department_name=c.department.Dname,Role_name=c.role.RoleName,Rep_Manager=(UserRegistration.Where(m=>m.UserId==(Emp_Reportings.Where(u=>u.Emp_ID==c.UserId).Select(u=>u.Rep_Mgr).FirstOrDefault())).Select(m=>m.Username).FirstOrDefault())}).FirstOrDefault();
            //   Department d = Departments.Where(x => x.DId == reg.DId).FirstOrDefault();
            //   employees.userId = reg.UserId;
            return employees;


        }

        public IEnumerable<Project> GetProjectDetails(string username)
        {
            List<Project> projs=new List<Project>();
            if(username==null)
            {
                return Projects.ToList();
            }
            else
            {
                IQueryable<int> query = Project_Teams.Where(t => t.Team_Id == (UserRegistration.Where(r => (r.Username == username || r.Email == username)).Select(r => r.UserId).FirstOrDefault())).Select(p => p.PId);
                foreach(int pid in query)
                {
                    projs.AddRange(Projects.Where(c => c.PID == pid));
                }

                return projs;
            }
        }

     

    }
}
