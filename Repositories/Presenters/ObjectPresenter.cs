﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

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
        public void ShowTable(bool sort = false)
        {
            dgvElements = objectRepository.GetTable();
            dgv.Rows.Clear();
            //id,address,adddate,cost,owner,appart,area,rooms
            foreach (DBObject obj in dgvElements)
                dgv.Rows.Add(obj.id, obj.address, obj.addDate.ToString("dd/MM/yyyy"), obj.cost, obj.owner, obj.appartamentOrHouse, obj.area, obj.numberOfRooms);
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public void AddToTable(DBObject obj)
        {
            objectRepository.AddToTable(obj);
        }
        public void UpdateTable(DBObject obj)
        {
            objectRepository.UpdateTable(obj);
        }
        public void DeleteFromTable(int id)
        {
            objectRepository.DeleteFromTable(id);
        }
    }
}