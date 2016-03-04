using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductCategoryMaster
    {
        public int ID { get; set; }
        public int ProductMasterID { get; set; }
        public int CategoryMasterID { get; set; }
        public int SubCategoryMasterID { get; set; }

    }
}