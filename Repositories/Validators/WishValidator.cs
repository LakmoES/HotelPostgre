using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class WishValidator
    {
        public static bool checkAddition(DBWish wish, out List<string> errorList)
        {
            errorList = new List<string>();
            if (wish.client <= 0)
            {
                errorList.Add("Не указан клиент.");
                return false;
            }
            return true;
        }
        public static bool checkDelete(int id, out List<string> errorList)
        {
            errorList = new List<string>();
            if (id <= 0)
            {
                errorList.Add("Неверная запись.");
                return false;
            }
            return true;
        }
    }
}
