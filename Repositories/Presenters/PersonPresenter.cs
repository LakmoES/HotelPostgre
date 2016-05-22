using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class PersonPresenter
    {
        DataGridView dgv;
        PersonRepository personRepository;
        List<DBPerson> dgvElements;

        public PersonPresenter(DataGridView dgv, string tableName)
        {
            dgvElements = new List<DBPerson>();
            this.dgv = dgv;
            personRepository = new PersonRepository(tableName);
        }
        public void ShowTable()
        {
            dgvElements = personRepository.GetTable();
            dgv.Rows.Clear();
            foreach (DBPerson person in dgvElements)
                dgv.Rows.Add(person.id, person.name, person.surname, person.telephone);
        }
        public void AddToTable(DBPerson person)
        {
            personRepository.AddToTable(person);
        }
        public void UpdateTable(DBPerson person)
        {
            personRepository.UpdateTable(person);
        }
        public void DeleteFromTable(int id)
        {
            personRepository.DeleteFromTable(id);
        }
    }
}
