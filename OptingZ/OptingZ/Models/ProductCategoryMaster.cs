using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductCategoryMaster
    {
        public int ID { get; set; }
        [ForeignKey("ProductMaster")]
        public int ProductMasterID { get; set; }
        [ForeignKey("CategoryMaster")]
        public int CategoryMasterID { get; set; }
        [ForeignKey("SubCategoryMaster")]
        public int SubCategoryMasterID { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual CategoryMaster CategoryMaster { get; set; }
        public virtual SubCategoryMaster SubCategoryMaster { get; set; }


    }
}