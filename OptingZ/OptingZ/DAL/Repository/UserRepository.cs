
using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.DAL
{
    public class UserRepository : Repository<UserMaster>
    {
        public UserRepository(OptingzDbContext context) : base(context)
        {

        }
    }
}