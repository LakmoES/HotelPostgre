using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class CompanyPresenter
    {
        DataGridView dgv;
        CompanyRepository companyRepository;
        List<DBCompany> dgvElements;

        public CompanyPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBCompany>();
            this.dgv = dgv;
            companyRepository = new CompanyRepository();
        }
        public void ShowTable(bool sort = false)
        {
            dgvElements = companyRepository.GetTable();
            dgv.Rows.Clear();
            //id, title, telephone, address
            foreach (DBCompany company in dgvElements)
                dgv.Rows.Add(company.id, company.title, company.telephone, company.address);
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public void AddToTable(DBCompany company)
        {
            companyRepository.AddToTable(company);
        }
        public void UpdateTable(DBCompany company)
        {
            companyRepository.UpdateTable(company);
        }
        public void DeleteFromTable(int id)
        {
            companyRepository.DeleteFromTable(id);
        }
    }
}
