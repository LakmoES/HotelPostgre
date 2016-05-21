using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class CompanyController
    {
        CompanyPresenter companyPresenter;
        DataGridView dgv;

        public CompanyController(DataGridView dgv/*, DBConnection dbc*/)
        {
            companyPresenter = new CompanyPresenter(dgv /*, dbc*/);
            this.dgv = dgv;
        }
        public void checkAddition(DBCompany company)
        {
            if (company.id < 0)
            { }
            else
            {
                //OK. Add the obj
                companyPresenter.AddToTable(company);
            }
        }
        public void checkDelete(int id)
        {
            if(id > 0)
                companyPresenter.DeleteFromTable(id);
        }
    }
}
