using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class CountryMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("GeoMaster")]
        public int GeoMasterID { get; set; }
        public virtual GeoMaster GeoMaster {get; set;}
    }
}