using System;
using System.Collections.Generic;
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
        public void ShowTable()
        {
            dgvElements = companyRepository.GetTable();
            dgv.Rows.Clear();
            //id, title, telephone, address
            foreach (DBCompany company in dgvElements)
                dgv.Rows.Add(company.id, company.title, company.telephone, company.address);
        }
        public void AddToTable(DBCompany company)
        {
            companyRepository.AddToTable(company);
        }
        public void UpdateTable(/*int n, */DBCompany company)
        {
            companyRepository.UpdateTable(company);
            //var companyList = companyRepository.GetTable();
            //DBCompany companyToUpdate = companyList.ElementAt(n);
            //companyRepository.UpdateTable(companyToUpdate, company);
        }
        public void DeleteFromTable(int id)
        {
            companyRepository.DeleteFromTable(id);
            //var companyList = companyRepository.GetTable();
            //DBCompany companyToDelete = companyList.ElementAt(n);
        }
    }
}
