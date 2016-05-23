using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class DealController
    {
        DealPresenter dealPresenter;
        DataGridView dgv;

        public DealController(DataGridView dgv)
        {
            dealPresenter = new DealPresenter(dgv);
            this.dgv = dgv;
        }
        public void checkAddition(DBDeal deal)
        {
            if (true)
            {
                //OK. Add the company
                dealPresenter.AddToTable(deal);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                dealPresenter.DeleteFromTable(id);
        }
    }
}
