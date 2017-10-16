using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Required, Display(Name = "Enter Name")]
        public string name { get; set; }

        [Display(Name = " Email")]
        [Required(ErrorMessage = "Email_id must not be empty")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        public string image { get; set; }
        public string Dob { get; set; }
    }
}