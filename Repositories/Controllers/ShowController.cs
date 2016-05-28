using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ShowController
    {
        ShowPresenter showPresenter;
        DataGridView dgv;

        public ShowController(DataGridView dgv)
        {
            showPresenter = new ShowPresenter(dgv);
            this.dgv = dgv;
        }
        public void checkAddition(DBShow show)
        {
            if (true)
            {
                //OK. Add the company
                showPresenter.AddToTable(show);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                showPresenter.DeleteFromTable(id);
        }
    }
}
