﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apifreader.Models
{
    public class User
    {
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string newPassword { get; set; }
    }
}