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
        ICompanyRepository companyRepository;

        public StaffPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBStaff>();
            this.dgv = dgv;
            staffRepository = new StaffRepository();
            companyRepository = RepositoryFactory.GetCompanyRepository();//new CompanyRepository();
        }
        public Dictionary<int, DBStaff> ShowTable(bool sort = false)
        {
            try
            {
                var companies = companyRepository.GetTable();
                dgvElements = staffRepository.GetTable();
                dgv.Rows.Clear();
                foreach (DBStaff staff in dgvElements)
                {
                    string companyText = null;
                    foreach (DBCompany company in companies)
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

            Dictionary<int, DBStaff> dict = new Dictionary<int, DBStaff>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(DBStaff staff)
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
        public bool UpdateTable(DBStaff staff)
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
