using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class DealValidator
    {
        public static bool checkAddition(DBDeal deal, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (deal.buyer <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан покупатель.");
            }
            if(deal.dealer <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан сотрудник.");
            }
            if(deal.obj <= 0 )
            {
                succeedFlag = false;
                errorList.Add("Укажите объект.");
            }
            if(deal.cost < 0)
            {
                succeedFlag = false;
                errorList.Add("Стоимость не может быть отрицательной.");
            }
            return succeedFlag;
        }
        public static bool checkDelete(int id, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (id <= 0)
            {
                succeedFlag = false;
                errorList.Add("Неверная запись.");
            }
            return succeedFlag;
        }
    }
}
