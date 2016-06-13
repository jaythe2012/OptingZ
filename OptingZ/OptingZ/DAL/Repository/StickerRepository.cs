using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.DAL.Repository
{
    public class StickerRepository : Repository<StickerMaster>
    {
        public StickerRepository(OptingzDbContext context) : base(context)
        {

        }

        public List<int> GetStickers(int sID)
        {
            List<int> sIDs = new List<int>();

            IEnumerable<StickerMaster> cm = context.StickerMasters.Where(p => p.ID == sID);

            return sIDs;
        }
    }
}