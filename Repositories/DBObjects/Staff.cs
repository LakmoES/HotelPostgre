using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Staff: Person
    {
        public int company;
        public Staff(int id, string name, string surname, string telephone, int company):base(id, name, surname, telephone)
        {
            this.company = company;
        }
    }
}
