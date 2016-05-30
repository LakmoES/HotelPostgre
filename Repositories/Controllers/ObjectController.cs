using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class ObjectController
    {
        public static bool checkAddition(DBObject obj)
        {
            if (obj.numberOfRooms > 0 && obj.cost > 0 && obj.address.Trim(' ').Length > 0 && obj.area > 0 && obj.owner > 0)
                return true;
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
