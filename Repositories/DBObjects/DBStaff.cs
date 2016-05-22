using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBStaff: DBPerson
    {
        public int company;
        public DBStaff(int id, string name, string surname, string telephone, int company):base(id, name, surname, telephone)
        {
            this.company = company;
        }
    }
}
