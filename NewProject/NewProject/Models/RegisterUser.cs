﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class RegisterUser
    {
        public int Id { get; set; }
        public string name  { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}