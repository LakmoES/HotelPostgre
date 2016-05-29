using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class WishController
    {
        public static bool checkAddition(DBWish wish)
        {
            if (wish.client > 0)
            {
                //OK. Add the wish
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
