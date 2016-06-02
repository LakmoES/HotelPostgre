using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Show
    {
        //id, Dealer, Client, Object, Date
        public int id;
        public int dealer;
        public int client;
        public int obj;
        public DateTime date;

        public Show(int id, int dealer, int client, int obj, DateTime date)
        {
            this.id = id;
            this.dealer = dealer;
            this.client = client;
            this.obj = obj;
            this.date = date;
        }
    }
}
