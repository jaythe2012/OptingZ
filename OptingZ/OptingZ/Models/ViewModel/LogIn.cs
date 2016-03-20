using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class LogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}