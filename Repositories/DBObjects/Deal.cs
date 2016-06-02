using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Deal
    {
        //id, Dealer, Buyer, Object, Cost, Date
        public int id;
        public int dealer;
        public int buyer;
        public int obj;
        public float cost;
        public DateTime date;

        public Deal(int id, int dealer, int buyer, int obj, float cost, DateTime date)
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
