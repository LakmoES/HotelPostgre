using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class StaffController
    {
        StaffPresenter staffPresenter;
        DataGridView dgv;

        public StaffController(DataGridView dgv)
        {
            staffPresenter = new StaffPresenter(dgv);
            this.dgv = dgv;
        }
        public void checkAddition(DBStaff staff)
        {
            if (staff.name.Trim(' ').Length >= 1 && staff.surname.Trim(' ').Length >= 1 && staff.telephone.Trim(' ').Length >= 1 && staff.company > 0)
            {
                //OK. Add the company
                staffPresenter.AddToTable(staff);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                staffPresenter.DeleteFromTable(id);
        }
    }
}
