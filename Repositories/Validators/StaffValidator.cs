using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class StaffValidator
    {
        public static bool checkAddition(Staff staff, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (staff.name.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Укажите имя.");
            }
            if(staff.surname.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Не указана фамилия.");
            }
            if (string.Concat(staff.name.Where(char.IsLetter)).Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Имя не может состоять только из цифр и спецсимволов");
            }
            if (string.Concat(staff.surname.Where(char.IsLetter)).Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Фамилия не может состоять только из цифр и спецсимволов");
            }
            if (staff.telephone.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Укажите номер телефона.");
            }
            else
            {
                string tempTel = staff.telephone;
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
            if (staff.company <= 0)
            {
                succeedFlag = false;
                errorList.Add("Укажите компанию.");
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
