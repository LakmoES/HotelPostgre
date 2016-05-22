using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBOwner: DBPerson
    {
        public DBOwner(int id, string name, string surname, string telephone):base(id, name, surname, telephone) { }
    }
}
