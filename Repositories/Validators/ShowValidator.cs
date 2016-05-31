using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ShowValidator
    {
        public static bool checkAddition(DBShow show, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (show.client <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан покупатель.");
            }
            if(show.dealer <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан сотрудник.");
            }
            if(show.obj <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан объект показа.");
            }
            return succeedFlag;
        }
        public static bool checkDelete(int id, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (id > 0)
            {
                succeedFlag = false;
                errorList.Add("Неверная запись.");
            }
            return succeedFlag;
        }
    }
}
