﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFirstApp.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}