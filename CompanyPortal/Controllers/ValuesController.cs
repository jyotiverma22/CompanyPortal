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
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        ICompanyRepository companyRepository;
        public ValuesController(ICompanyRepository repository)
        {
            companyRepository = repository;
        }


        /// <summary>
        /// function for checking if username already exists or not
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet, Route("checkUsernameStatus")]
        public IHttpActionResult checkUsernameStatus(String username)
        {
            return Ok(companyRepository.CheckUsernameStatus(username));
        }

        /// for checking if email already exists or not<summary>
        /// function 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet, Route("checkEmailStatus")]
        public IHttpActionResult checkEmailStatus(string email)
        {

            return Ok(companyRepository.CheckEmailAddressStatus(email));
        }


        /// <summary>
        /// saving the user's information into the database
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        [HttpPost, Route("saveuserDetails")]
        public IHttpActionResult saveUserDetails([FromBody] RegisterViewModel registerViewModel)
        {
            //mapping the register view model into the registration model
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegisterViewModel, Registration>().ForMember(t=>t.Sno,options=>options.Ignore())
                                        .ForMember(t=>t.bloodGroup,options=>options.Ignore())
                                        .ForMember(t => t.department, options => options.Ignore())
                                        .ForMember(t => t.DId, options => options.Ignore())
                                        .ForMember(t => t.role, options => options.Ignore())
                                        .ForMember(t => t.RId, options => options.Ignore())
                                        .ForMember(t=>t.BId,options=>options.MapFrom(src=>src.Bloodgroup));

            });

            IMapper mapper = config.CreateMapper();
            Registration reg=mapper.Map<RegisterViewModel, Registration>(registerViewModel);

            return Ok(companyRepository.AddUsers(reg));
        }



        /// <summary>
        /// Getting the custom user Id eg-cmp-1001
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetUserId")]
        public IHttpActionResult GetUserId()
        {
            return Ok(companyRepository.GetUserId());
        }


        /// <summary>
        /// getting all bloodgroups into the drop down
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBloodGroups")]
        public IHttpActionResult GetBloodGroups()
        {
            return Ok(companyRepository.GetBloodGroups());
        }


        /// <summary>
        /// check username and password if user exists
        /// </summary>
        /// <param name="loginviewModel"></param>
        /// <returns></returns>
       [HttpPost,Route("CheckUser")]
       public IHttpActionResult CheckUser([FromBody] LoginViewModel loginviewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginViewModel, Login>();

            });

            IMapper mapper = config.CreateMapper();
            Login login= mapper.Map<LoginViewModel, Login>(loginviewModel);
            return Ok(companyRepository.CheckUser(login));
        }


        /// <summary>
        /// saving the error into the database
        /// </summary>
        /// <param name="dbLogging"></param>
        /// <returns></returns>
       [HttpPost]
       public bool SaveErrorLoggingDetails(DbLogging dbLogging)
        {
            return (companyRepository.SaveErrorLoggingDetails(dbLogging));
        }

        [HttpGet]
       public IEnumerable<string> GetallProjectManagers()
        {
            return companyRepository.getAllProjectManagers();
        }        
    }
}
