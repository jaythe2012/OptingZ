using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductLocationMaster
    {
        public int ID { get; set; }
        public int ProductMasterID { get; set; }
        public int GeoMasterID { get; set; }
        public int CountryMasterID { get; set; }
        public int StateMasterID { get; set; }
        public int CityMasterID { get; set; }

    }
}