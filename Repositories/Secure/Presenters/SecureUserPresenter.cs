using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Repositories
{
    public class SecureUserPresenter
    {
        DataGridView dgv;
        List<SecureDBUser> dgvElements;

        IStaffRepository staffRepository;
        ICompanyRepository companyRepository;

        public SecureUserPresenter(DataGridView dgv)
        {
            dgvElements = new List<SecureDBUser>();
            this.dgv = dgv;

            staffRepository = RepositoryFactory.GetStaffRepository();
            companyRepository = RepositoryFactory.GetCompanyRepository();
        }
        private Dictionary<int, Staff> GetStaffs()
        {

            var staffs = staffRepository.GetTable();
            var assocArray = new Dictionary<int, Staff>();

            foreach (Staff staff in staffs)
                assocArray.Add(staff.id, staff);

            return assocArray;
        }
        private Dictionary<int, Company> GetCompanies()
        {
            var companies = companyRepository.GetTable();
            var assocArray = new Dictionary<int, Company>();

            foreach (Company company in companies)
                assocArray.Add(company.id, company);

            return assocArray;
        }
        public void ShowTable(bool sort = false)
        {
            try
            {
                dgvElements = SecureUserRepository.GetTable();
                dgv.Rows.Clear();
                foreach (SecureDBUser user in dgvElements)
                {
                    string thirdField = "";
                    thirdField = user.subgroup.ToString();
                    //if (SecureConst.GetRoleName(user.db_role) == "Director")
                    //{
                    //    //var companies = GetCompanies();
                    //    DBCompany company = companyRepository.GetConcreteRecord(user.subrole);
                    //    //companies.TryGetValue(user.subrole, out company);
                    //    thirdField = String.Format("[{0}] {1}", company.id, company.title);
                    //}
                    //if (SecureConst.GetRoleName(user.db_role) == "Staff")
                    //{
                    //    //var staffs = GetStaffs();
                    //    DBStaff staff = staffRepository.GetConcreteRecord(user.subrole);
                    //    //staffs.TryGetValue(user.subrole, out staff);
                    //    thirdField = String.Format("[{0}] {1} {2}", staff.id, staff.surname, staff.name);
                    //}

                    dgv.Rows.Add(user.name,
                        String.Format("[{0}] {1}", user.db_role, SecureConst.GetRoleName(user.db_role)),
                        thirdField
                        );
                }
            }
            catch (PostgresException pEx) { MessageBox.Show("Ошибка базы данных.\r\n" + pEx.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception) { MessageBox.Show("Неизвестная ошибка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public bool AddToTable(SecureDBUser user)
        {
            List<string> errorList;
            bool checkFlag = SecureUserValidator.checkAddition(user, out errorList);
            try
            {
                if (checkFlag)
                    SecureUserRepository.AddToTable(user);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(SecureDBUser user)
        {
            List<string> errorList;
            bool checkFlag = SecureUserValidator.checkAddition(user, out errorList);
            try
            {
                if (checkFlag)
                    SecureUserRepository.UpdateTable(user);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(string name)
        {
            List<string> errorList;
            bool checkFlag = SecureUserValidator.checkDelete(name, out errorList);
            try
            {
                if (checkFlag)
                    SecureUserRepository.DeleteFromTable(name);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

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
