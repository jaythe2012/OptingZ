using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class UserDetailMaster
    {
        public int ID { get; set; }
        [ForeignKey("UserMaster")]
        public int UserMasterID { get; set; } 
        public DateTime BirthDate { get; set; }
        public String Sex { get; set; }
        public String PhoneNumber { get; set; }
        public bool IsSubscribedByEmail { get; set; }

        public virtual UserMaster UserMaster { get; set; }
    }
}