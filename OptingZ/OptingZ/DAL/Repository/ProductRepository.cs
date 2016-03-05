using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptingZ.Models;

namespace OptingZ.DAL
{
    public class ProductRepository : Repository<ProductMaster>
    {
        public ProductRepository(OptingzDbContext context) : base(context)
        {
        }
    }
}