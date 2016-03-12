using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class CityMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("StateMaster")]
        public int StateMasterID { get; set; }
        public virtual StateMaster StateMaster { get; set; }
    }
}