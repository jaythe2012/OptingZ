using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptingZ.Models;

namespace OptingZ.DAL
{
    public class UserFileRepository : Repository<UserFileMaster>
    {
        public UserFileRepository(OptingzDbContext context) : base(context)
        {

        }
    }
}