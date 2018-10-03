using AutoMapper;
using CompanyPortal.ViewModels;
using Models;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CompanyPortal.Controllers
{

    //Api controller after the user logged in
    [RoutePrefix("api/details")]
    public class DetailsController : ApiController
    {
        ICompanyRepository ICompany;

        public DetailsController(ICompanyRepository IComapanyrepository)
        {
            ICompany = IComapanyrepository;
        }

        [HttpGet,Route("getEmployeeDetails"),Authorize]
        
       public IHttpActionResult getEmployeeDetails(string username)
        {
           
            EmployeesDetails emp= ICompany.GetEmployeesDetails(username);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeesDetails,EmployeeDetailsViewModel > ();

            });

            IMapper mapper = config.CreateMapper();
            EmployeeDetailsViewModel empViewModel = mapper.Map<EmployeesDetails, EmployeeDetailsViewModel>(emp);

            return Ok(empViewModel);
        }


        // Get project details to show into the jqgrid
        [Authorize, HttpGet, Route("getProjectDetails")]
        public IEnumerable<ProjectViewModel> GetProjectDetails(string username,string status)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<ProjectViewModel> projs = new List<ProjectViewModel>();
            List<Project> project = new List<Project>();
            project = ICompany.GetProjectDetail(username,status).ToList();
                projs = mapper.Map<List<Project>, List<ProjectViewModel>>(project);
            return projs;
        }


        [Authorize, HttpGet, Route("getTeamDetails")]
        public IEnumerable<RegisterViewModel> getTeamDetails(int pid)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegisterViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<RegisterViewModel> regs = new List<RegisterViewModel>();
            List<Registration> emp = new List<Registration>();
            emp = ICompany.getTeamDetails(pid).ToList();
            regs = mapper.Map<List<Registration>, List<RegisterViewModel>>(emp);
            return regs;
        }

        [HttpPost, Route("addProjectDetails")]
        public bool AddProjectDetails(ProjectViewModel projectViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectViewModel, Project>()
                .ForMember(t=>t.PID,o=>o.Ignore())
                .ForMember(t=>t.Status,o=>o.MapFrom(opt=>"working"))
                .ForMember(t=>t.ProjectName,o=>o.MapFrom(opt=>opt.Project_Name));
            });

            IMapper mapper = config.CreateMapper();
            Project project = new Project();
            project = mapper.Map<ProjectViewModel, Project>(projectViewModel);
            return ICompany.AddProjects(project);
        }


        // [Authorize, Route("getprojectdetails"), HttpGet]
        //public IHttpActionResult getProjectDetails()
        // {
        //     string username = null;
        //     return null;
        // }


    }
}
