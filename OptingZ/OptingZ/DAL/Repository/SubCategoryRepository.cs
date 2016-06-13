using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.DAL.Repository
{
    public class SubCategoryRepository : Repository<SubCategoryMaster>
    {
        public SubCategoryRepository(OptingzDbContext context) : base(context)
        {

        }

        public List<int> GetSubCategory(int scID)
        {
            List<int> scIDs = new List<int>();

            IEnumerable<SubCategoryMaster> cm = context.SubCategoryMasters.Where(p => p.ID == scID);

            return scIDs;
        }
    }
}