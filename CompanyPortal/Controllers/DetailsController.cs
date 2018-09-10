using AutoMapper;
using CompanyPortal.ViewModels;
using Models;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        [Authorize, Route("getemployeedetails"), HttpGet]
        IHttpActionResult getProjectDetails(string username)
        {
            return Ok();
        }



    }
}
