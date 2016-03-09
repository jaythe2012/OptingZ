using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OptingZ.Models;

namespace OptingZ.DAL
{
    public class ProductCategoryRepository : Repository<ProductCategoryMaster>
    {
        public ProductCategoryRepository(OptingzDbContext context) : base(context)
        {

        }

        public List<int> GetProductsBySubCategoryID(int subcategoryID)
        {
            List<int> productIDs = new List<int>() ;

            IEnumerable<ProductCategoryMaster> cm = context.ProductCategoryMasters.Where(p => p.SubCategoryMasterID == subcategoryID);

            foreach(ProductCategoryMaster cms in cm)
            {
                productIDs.Add(cms.ProductMasterID);
            }

            return productIDs;

        }

    }
}