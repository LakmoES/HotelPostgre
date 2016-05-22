using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        CompanyRepository companyRepository;

        public StaffPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBStaff>();
            this.dgv = dgv;
            staffRepository = new StaffRepository();
            companyRepository = new CompanyRepository();
        }
        public void ShowTable(bool sort = false)
        {
            var companies = companyRepository.GetTable();
            dgvElements = staffRepository.GetTable();
            dgv.Rows.Clear();
            foreach (DBStaff staff in dgvElements)
            {
                string companyText = null;
                foreach(DBCompany company in companies)
                    if(staff.company == company.id)
                    {
                        companyText = String.Format("[{0}] {1}", company.id, company.title);
                        break;
                    }
                dgv.Rows.Add(staff.id, staff.name, staff.surname, staff.telephone, companyText);
            }
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
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
