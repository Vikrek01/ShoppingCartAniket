﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartAssignment.Models
{
    public class User
    {        
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Role { get; set; } = "User";

      

        
    }
}