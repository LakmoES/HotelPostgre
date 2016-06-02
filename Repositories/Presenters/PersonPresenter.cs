using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class PersonPresenter
    {
        DataGridView dgv;
        IPersonRepository personRepository;
        List<DBPerson> dgvElements;

        public PersonPresenter(DataGridView dgv, string tableName)
        {
            dgvElements = new List<DBPerson>();
            this.dgv = dgv;
            personRepository = new PersonRepository(tableName);
        }
        public Dictionary<int, DBPerson> ShowTable(bool sort = false)
        {
            try
            {
                dgvElements = personRepository.GetTable();
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            dgv.Rows.Clear();
            foreach (DBPerson person in dgvElements)
                dgv.Rows.Add(person.id, person.name, person.surname, person.telephone);
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, DBPerson> dict = new Dictionary<int, DBPerson>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(DBPerson person)
        {
            List<string> errorList;
            bool checkFlag = PersonValidator.checkAddition(person, out errorList);
            try
            {
                if (checkFlag)
                    personRepository.AddToTable(person);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(DBPerson person)
        {
            List<string> errorList;
            bool checkFlag = PersonValidator.checkAddition(person, out errorList);
            try
            {
                if (checkFlag)
                    personRepository.UpdateTable(person);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = PersonValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    personRepository.DeleteFromTable(id);
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
