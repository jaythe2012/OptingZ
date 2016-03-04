using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class StateMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryMasterID { get; set; }
    }
}