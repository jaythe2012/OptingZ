using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductDescriptionMaster
    {
        public int ID { get; set; }
        public int ProductMasterID { get; set; }
        public string Description { get; set; }
    }
}