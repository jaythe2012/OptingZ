using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.DAL.Repository
{
    public class CategoryRepository : Repository<CategoryMaster>
    {
        public CategoryRepository(OptingzDbContext context) : base(context)
        {

        }

        public List<int> GetCategory(int cID)
        {
            List<int> cIDs = new List<int>();

            IEnumerable<CategoryMaster> cm = context.CategoryMasters.Where(p => p.ID == cID);

            return cIDs;
        }
    }
}