using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ShowController
    {
        public static bool checkAddition(DBShow show)
        {
            if (show.client > 0 && show.dealer > 0 && show.obj > 0)
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
