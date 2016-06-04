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
        IStaffRepository staffRepository;
        List<Staff> dgvElements;
        ICompanyRepository companyRepository;

        public StaffPresenter(DataGridView dgv, IRepositoryFactory repositoryFactory)
        {
            dgvElements = new List<Staff>();
            this.dgv = dgv;
            staffRepository = repositoryFactory.GetStaffRepository();
            companyRepository = repositoryFactory.GetCompanyRepository();//new CompanyRepository();
        }
        public Dictionary<int, Staff> ShowTable(bool sort = false)
        {
            try
            {
                var companies = companyRepository.GetTable();
                dgvElements = staffRepository.GetTable();
                dgv.Rows.Clear();
                foreach (Staff staff in dgvElements)
                {
                    string companyText = null;
                    foreach (Company company in companies)
                        if (staff.company == company.id)
                        {
                            companyText = String.Format("{1}", company.id, company.title);
                            break;
                        }
                    dgv.Rows.Add(staff.id, staff.name, staff.surname, staff.telephone, companyText);
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, Staff> dict = new Dictionary<int, Staff>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Staff staff)
        {
            List<string> errorList;
            bool checkFlag = StaffValidator.checkAddition(staff, out errorList);
            try
            {
                if (checkFlag)
                    staffRepository.AddToTable(staff);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(Staff staff)
        {
            List<string> errorList;
            bool checkFlag = StaffValidator.checkAddition(staff, out errorList);
            try
            {
                if (checkFlag)
                    staffRepository.UpdateTable(staff);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = StaffValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    staffRepository.DeleteFromTable(id);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

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
