using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBDeal
    {
        //id, Dealer, Buyer, Object, Cost, Date
        public int id;
        public int dealer;
        public int buyer;
        public int obj;
        public int cost;
        public DateTime date;

        public DBDeal(int id, int dealer, int buyer, int obj, int cost, DateTime date)
        {
            this.id = id;
            this.dealer = dealer;
            this.buyer = buyer;
            this.obj = obj;
            this.cost = cost;
            this.date = date;
        }
    }
}
