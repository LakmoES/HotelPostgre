using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ObjectPresenter
    {
        DataGridView dgv;
        ObjectRepository objectRepository;
        List<DBObject> dgvElements;

        public ObjectPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBObject>();
            this.dgv = dgv;
            objectRepository = new ObjectRepository();
        }
        public void ShowTable()
        {
            dgvElements = objectRepository.GetTable();
            dgv.Rows.Clear();
            //id,address,adddate,cost,owner,appart,area,rooms
            foreach (DBObject obj in dgvElements)
                dgv.Rows.Add(obj.id, obj.address, obj.addDate.ToString("dd/MM/yyyy"), obj.cost, obj.owner, obj.appartamentOrHouse, obj.area, obj.numberOfRooms);
        }
        public void AddToTable(DBObject obj)
        {
            objectRepository.AddToTable(obj);
        }
        public void UpdateTable(int n, DBObject obj)
        {
            var objList = objectRepository.GetTable();
            DBObject objToUpdate = objList.ElementAt(n);
            objectRepository.UpdateTable(objToUpdate, obj);
        }
        public void DeleteFromTable(int id)
        {
            objectRepository.DeleteFromTable(id);
            //var objList = objectRepository.GetTable();
            //DBObject objToDelete = objList.ElementAt(n);
            //objectRepository.DeleteFromTable(objToDelete);
        }
    }
}
