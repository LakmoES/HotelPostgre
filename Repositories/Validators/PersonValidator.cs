using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class PersonValidator
    {
        public static bool checkAddition(Person person, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (person.name.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Укажите имя.");
            }
            if(person.surname.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Укажите фамилию.");
            }
            if(person.telephone.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указан номер телефона.");
            }
            else
            {
                string tempTel = person.telephone;
                int k = tempTel.IndexOf('+');
                while (k != -1)
                {
                    tempTel = tempTel.Remove(k, 1);
                    k = tempTel.IndexOf('+');
                }

                k = tempTel.IndexOf('-');
                while (k != -1)
                {
                    tempTel = tempTel.Remove(k, 1);
                    k = tempTel.IndexOf('-');
                }

                k = tempTel.IndexOf('(');
                while (k != -1)
                {
                    tempTel = tempTel.Remove(k, 1);
                    k = tempTel.IndexOf('(');
                }

                k = tempTel.IndexOf(')');
                while (k != -1)
                {
                    tempTel = tempTel.Remove(k, 1);
                    k = tempTel.IndexOf(')');
                }

                k = tempTel.IndexOf(' ');
                while (k != -1)
                {
                    tempTel = tempTel.Remove(k, 1);
                    k = tempTel.IndexOf(' ');
                }

                UInt64 telephone;
                bool checkTelephone = UInt64.TryParse(tempTel, out telephone);

                if (tempTel.Length < 6)
                    checkTelephone = false;

                if (!checkTelephone)
                {
                    succeedFlag = false;
                    errorList.Add("Неверный формат номера телефона.");
                }
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
