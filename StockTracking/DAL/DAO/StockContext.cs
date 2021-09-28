using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class StockContext
    {
        public StockTrakingEntities1 db = new StockTrakingEntities1();
    }
}
