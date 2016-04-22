using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OptingZ.Models;
using Newtonsoft.Json;

namespace OptingZ.DAL
{
    public class ProductRepository : Repository<ProductMaster>
    {
        public ProductRepository(OptingzDbContext context) : base(context)
        {
        }

        internal IEnumerable<ProductMaster> GetNames(string term)
        {

            var products = context.ProductMasters.Where(p => p.Name.StartsWith(term)); 
            return products;


        }
    }
}