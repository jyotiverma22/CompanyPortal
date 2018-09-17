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
        public IEnumerable<ProjectViewModel> GetProjectDetails(string username)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<ProjectViewModel> projs = new List<ProjectViewModel>();
            List<Project> project = new List<Project>();
            project = ICompany.GetProjectDetail(username).ToList();
                projs = mapper.Map<List<Project>, List<ProjectViewModel>>(project);
            return projs;
        }


       // [Authorize, Route("getprojectdetails"), HttpGet]
       //public IHttpActionResult getProjectDetails()
       // {
       //     string username = null;
       //     return null;
       // }


    }
}
