using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public static class CompanyValidator
    {
        public static bool checkAddition(DBCompany company, out List<string> errorList)
        {
            errorList = new List<string>();
            bool succeedFlag = true;
            if (company.title.Trim(' ').Length <= 0 )
            {
                succeedFlag = false;
                errorList.Add("Название филиала не может быть пустым.");
            }
            if(company.address.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Адрес филиала не может быть пустым.");
            }
            if(company.telephone.Trim(' ').Length <= 0)
            {
                succeedFlag = false;
                errorList.Add("Должен быть указан номер телефона.");
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
                errorList.Add("Попытка удаления несуществующей записи.");
            }
            return succeedFlag;
        }
    }
}
