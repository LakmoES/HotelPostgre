using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DBObjects
{
    class DBClient: DBPerson
    {
        public DBClient(int id, string name, string surname, string telephone):base(id, name, surname, telephone) { }
    }
}
