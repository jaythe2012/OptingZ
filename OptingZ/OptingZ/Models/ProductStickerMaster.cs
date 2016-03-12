using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class ProductStickerMaster
    {
        public int ID { get; set; }
        [ForeignKey("ProductMaster")]
        public int ProductMasterID { get; set; }
        [ForeignKey("StickerMaster")]
        public int StickerMasterID { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual StickerMaster StickerMaster { get; set; }
    }
}