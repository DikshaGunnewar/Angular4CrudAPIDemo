using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class RegisterUserContext:DbContext
    {
        public  RegisterUserContext():base("name= RegisterUserContext")
        {

        }
        public DbSet<RegisterUser> RegisterUsers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<twitter> twitters { get; set; }
    }
}