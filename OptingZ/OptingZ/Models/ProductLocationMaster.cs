using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductLocationMaster
    {
        public int ID { get; set; }
        [ForeignKey("ProductMaster")]
        public int ProductMasterID { get; set; }
        [ForeignKey("GeoMaster")]
        public int GeoMasterID { get; set; }
        [ForeignKey("CountryMaster")]
        public int CountryMasterID { get; set; }
        [ForeignKey("StateMaster")]
        public int StateMasterID { get; set; }
        [ForeignKey("CityMaster")]
        public int CityMasterID { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual GeoMaster GeoMaster { get; set; }
        public virtual CountryMaster CountryMaster { get; set; }
        public virtual StateMaster StateMaster { get;  set; }
        public virtual CityMaster CityMaster { get; set; }


    }
}