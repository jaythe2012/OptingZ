using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class CityMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StateMasterID { get; set; }
    }
}