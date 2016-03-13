using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptingZ.Models;

namespace OptingZ.DAL
{
    public class UserDetailRepository : Repository<UserDetailMaster>
    {
        public UserDetailRepository(OptingzDbContext context) : base(context)
        { }

        public UserDetailMaster GetUserDetailByUserID(int userID)
        {
            UserDetailMaster userDetailMaster = context.UserDetailMasters.Where(p => p.UserMasterID == userID).SingleOrDefault();
            return userDetailMaster;
        }
    }
}