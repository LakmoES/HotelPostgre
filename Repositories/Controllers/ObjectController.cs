using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ObjectController
    {
        //DBConnection dbc;
        ObjectPresenter objectPresenter;
        DataGridView dgv;

        public ObjectController(DataGridView dgv/*, DBConnection dbc*/)
        {
            objectPresenter = new ObjectPresenter(dgv /*, dbc*/);
            this.dgv = dgv;
        }
        public void checkAddition(DBObject obj)
        {
            if (obj.numberOfRooms <= 0 || obj.cost <= 0 || obj.address.Length == 0 || obj.area <= 0 || obj.owner <= 0)
            { }
            else
            {
                //OK. Add the obj
                objectPresenter.AddToTable(obj);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                objectPresenter.DeleteFromTable(id);
        }
    }
}
