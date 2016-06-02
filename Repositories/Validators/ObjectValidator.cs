using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class ObjectValidator
    {
        public static bool checkAddition(Entity obj, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (obj.numberOfRooms < 0)
            {
                succeedFlag = false;
                errorList.Add("Неверное количество комнат.");
            }
            if(obj.cost < 0)
            {
                succeedFlag = false;
                errorList.Add("Стоимость не может быть отрицательной.");
            }
            if(obj.address.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан адрес.");
            }
            if(obj.area <= 0)
            {
                succeedFlag = false;
                errorList.Add("Неверно указана площадь.");
            }
            if(obj.owner <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан владелец.");
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
                errorList.Add("Несуществующая запись.");
            }
            return succeedFlag;
        }
    }
}
