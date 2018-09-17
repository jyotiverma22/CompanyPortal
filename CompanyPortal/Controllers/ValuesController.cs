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



        [HttpPost, Route("checkUsernameStatus")]
        public IHttpActionResult checkUsernameStatus(String username)
        {
            return Ok(companyRepository.CheckUsernameStatus(username));
        }


        [HttpPost, Route("checkEmailStatus")]
        public IHttpActionResult checkEmailStatus(string email)
        {

            return Ok(companyRepository.CheckEmailAddressStatus(email));
        }

        [HttpPost, Route("saveuserDetails")]
        public IHttpActionResult saveUserDetails([FromBody] RegisterViewModel registerViewModel)
        {
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

        [HttpGet, Route("GetUserId")]
        public IHttpActionResult GetUserId()
        {
            return Ok(companyRepository.GetUserId());
        }

        [HttpGet, Route("GetBloodGroups")]
        public IHttpActionResult GetBloodGroups()
        {
            return Ok(companyRepository.GetBloodGroups());
        }

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

      


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
