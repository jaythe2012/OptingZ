using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductMaster 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SDescription { get; set; }
        public bool IsMultipleCategory { get; set; }
        public string Website { get; set; }

        public virtual ICollection<ProductCategoryMaster> ProductCategorises { get; set; }
        public virtual ICollection<ProductLocationMaster> ProductLocations { get; set; }
        public virtual ICollection<ProductStickerMaster> ProductStickers { get; set; }
    }
}