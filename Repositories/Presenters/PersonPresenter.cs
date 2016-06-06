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
        List<Person> dgvElements;

        public PersonPresenter(DataGridView dgv, IRepositoryFactory repositoryFactory, string tableName)
        {
            dgvElements = new List<Person>();
            this.dgv = dgv;
            personRepository = repositoryFactory.GetPersonRepository(tableName);
        }
        public Dictionary<int, Person> ShowTable(bool sort = false)
        {
            try
            {
                dgvElements = personRepository.GetTable();
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            dgv.Rows.Clear();
            foreach (Person person in dgvElements)
                dgv.Rows.Add(person.id, person.name, person.surname, person.telephone);
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, Person> dict = new Dictionary<int, Person>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Person person)
        {
            List<string> errorList;
            bool checkFlag = PersonValidator.checkAddition(person, out errorList);
            try
            {
                if (checkFlag)
                    personRepository.AddToTable(person);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(Person person)
        {
            List<string> errorList;
            bool checkFlag = PersonValidator.checkAddition(person, out errorList);
            try
            {
                if (checkFlag)
                    personRepository.UpdateTable(person);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
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
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
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
