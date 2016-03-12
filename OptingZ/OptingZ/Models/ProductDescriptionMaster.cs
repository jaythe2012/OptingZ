using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductDescriptionMaster
    {
        public int ID { get; set; }
        [ForeignKey("ProductMaster")]
        public int ProductMasterID { get; set; }
        public string Description { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
    }
}