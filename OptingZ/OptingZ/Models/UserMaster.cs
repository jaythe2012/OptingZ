using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptingZ.Models
{
    public class UserMaster
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserRoleMaster")]
        public int UserRoleMasterID { get; set; }
        public virtual UserFileMaster UserFiles { get; set; }
        public virtual UserRoleMaster UserRoleMaster { get; set; }
        public virtual UserDetailMaster UserDetailMaster { get; set; }
    }
}