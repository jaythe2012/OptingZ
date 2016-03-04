using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class CountryMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GeoMasterID { get; set; }
    }
}