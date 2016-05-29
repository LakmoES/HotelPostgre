using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class PersonController
    {
        public static bool checkAddition(DBPerson person)
        {
            if (person.name.Trim(' ').Length >= 1 && person.surname.Trim(' ').Length >= 1 && person.telephone.Trim(' ').Length >= 1)
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
