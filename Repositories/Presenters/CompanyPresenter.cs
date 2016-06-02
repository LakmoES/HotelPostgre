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
        ICompanyRepository companyRepository;
        List<Company> dgvElements;

        public CompanyPresenter(DataGridView dgv)
        {
            dgvElements = new List<Company>();
            this.dgv = dgv;
            companyRepository = RepositoryFactory.GetCompanyRepository()/*new CompanyRepository()*/;
        }
        public Dictionary<int, Company> ShowTable(bool sort = false)
        {
            try
            {
                dgvElements = companyRepository.GetTable();
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            dgv.Rows.Clear();
            foreach (Company company in dgvElements)
                dgv.Rows.Add(company.id, company.title, company.telephone, company.address);
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, Company> dict = new Dictionary<int, Company>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Company company)
        {
            List<string> errorList;
            bool checkFlag = CompanyValidator.checkAddition(company, out errorList);
            try
            {
                if (checkFlag)
                    companyRepository.AddToTable(company);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(Company company)
        {
            List<string> errorList;
            bool checkFlag = CompanyValidator.checkAddition(company, out errorList);
            try
            {
                if (checkFlag)
                    companyRepository.UpdateTable(company);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = CompanyValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    companyRepository.DeleteFromTable(id);
            }
            catch(Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        private void ShowErrors(List<string> errorList)
        {
            if (errorList.Count == 0)
                return;

            string errors = "";
            foreach (string s in errorList)
                errors += s + System.Environment.NewLine;
            MessageBox.Show(errors, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
