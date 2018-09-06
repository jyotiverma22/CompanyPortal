﻿using AutoMapper;
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
                cfg.CreateMap<RegisterViewModel, Registration>().ForMember(t=>t.Sno,options=>options.Ignore());
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