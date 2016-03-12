using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class StateMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CountryMaster")]
        public int CountryMasterID { get; set; }

        public virtual CountryMaster CountryMaster { get; set; }
    }
}