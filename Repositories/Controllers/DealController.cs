using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class DealController
    {
        public static bool checkAddition(DBDeal deal)
        {
            if (deal.buyer > 0 && deal.dealer > 0 && deal.obj > 0 && deal.cost >= 0)
            {
                //OK. Add the company
                return true;
            }
            return false;
        }
        public static bool checkDelete(int id)
        {
            if (id > 0)
                return true;
            return false;
        }
    }
}
