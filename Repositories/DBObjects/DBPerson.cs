using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBPerson
    {
        //id, "Name", "Surname", "Telephone"
        public int id;
        public string name;
        public string surname;
        public string telephone;
        public DBPerson(int id, string name, string surname, string telephone)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.telephone = telephone;
        }
    }
}
