﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCinema.Dal;
using ProjectCinema.Models;

namespace ProjectCinema.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}