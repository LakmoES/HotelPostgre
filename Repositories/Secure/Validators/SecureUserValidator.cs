using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class SecureUserValidator
    {
        public static bool checkAddition(SecureDBUser user, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if(user.name.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Имя не может быть пустым.");
            }
            if (user.password.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Пароль не может быть пустым.");
            }
            if (user.db_role <= 0 || user.db_role > 3)
            {
                succeedFlag = false;
                errorList.Add("Роль должна принадлежать промежутку [1,3]");
            }
            if (user.subrole <= 0)
            {
                succeedFlag = false;
                errorList.Add("Подроль должна быть больше нуля");
            }

            return succeedFlag;
        }
        public static bool checkDelete(string name, out List<string> errorList)
        {
            errorList = new List<string>();
            if(name.Trim(' ').Length <= 0)
            {
                errorList.Add("Неверная запись.");
                return false;
            }
            return true;
        }
    }
}
