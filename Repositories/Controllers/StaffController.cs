using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class StaffController
    {
        public static bool checkAddition(DBStaff staff)
        {
            if (staff.name.Trim(' ').Length >= 1 && staff.surname.Trim(' ').Length >= 1 && staff.telephone.Trim(' ').Length >= 1 && staff.company > 0)
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
