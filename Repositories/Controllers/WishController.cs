using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class WishController
    {
        WishPresenter wishPresenter;
        DataGridView dgv;

        public WishController(DataGridView dgv)
        {
            wishPresenter = new WishPresenter(dgv);
            this.dgv = dgv;
        }
        public void checkAddition(DBWish wish)
        {
            if (true)
            {
                //OK. Add the wish
                wishPresenter.AddToTable(wish);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                wishPresenter.DeleteFromTable(id);
        }
    }
}
