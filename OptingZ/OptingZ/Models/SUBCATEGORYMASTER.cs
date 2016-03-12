using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class SubCategoryMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryMaster")]
        public int CategoryMasterID { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }
    }
}