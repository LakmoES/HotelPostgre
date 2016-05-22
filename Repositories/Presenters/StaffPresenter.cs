using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class StaffPresenter
    {
        DataGridView dgv;
        StaffRepository staffRepository;
        List<DBStaff> dgvElements;

        public StaffPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBStaff>();
            this.dgv = dgv;
            staffRepository = new StaffRepository();
        }
        public void ShowTable()
        {
            dgvElements = staffRepository.GetTable();
            dgv.Rows.Clear();
            foreach (DBStaff staff in dgvElements)
                dgv.Rows.Add(staff.id, staff.name, staff.surname, staff.telephone, staff.company);
        }
        public void AddToTable(DBStaff staff)
        {
            staffRepository.AddToTable(staff);
        }
        public void UpdateTable(DBStaff staff)
        {
            staffRepository.UpdateTable(staff);
        }
        public void DeleteFromTable(int id)
        {
            staffRepository.DeleteFromTable(id);
        }
    }
}
