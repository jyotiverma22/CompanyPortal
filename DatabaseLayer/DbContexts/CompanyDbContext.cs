﻿using Microsoft.EntityFrameworkCore;
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


        public bool UserCheck(Login login)
        {
         //   login.Password = Password.EncodePassword(login.Password,login.Username);

            Registration user = UserRegistration.Where(x =>   (x.Username==login.Username||x.Email==login.Username)).FirstOrDefault();
            if(user!=null)
            {
                login.Password = Password.EncodePassword(login.Password, user.Username);
                if(user.Password==login.Password)
                {
                    return true;
                }
                return false;
            }

            return false;
        }



     

    }
}
