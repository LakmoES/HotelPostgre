using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories.Controllers
{
    public class PersonController
    {
        PersonPresenter personPresenter;
        DataGridView dgv;

        public PersonController(DataGridView dgv, string tableName)
        {
            personPresenter = new PersonPresenter(dgv, tableName);
            this.dgv = dgv;
        }
        public void checkAddition(DBPerson person)
        {
            if (person.name.Trim(' ').Length >= 1 && person.surname.Trim(' ').Length >= 1 && person.telephone.Trim(' ').Length >= 1)
            {
                //OK. Add the company
                personPresenter.AddToTable(person);
            }
        }
        public void checkDelete(int id)
        {
            if (id > 0)
                personPresenter.DeleteFromTable(id);
        }
    }
}
