using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPersonRepository
    {
        List<DBPerson> GetTable();
        DBPerson GetConcreteRecord(int id);
        void AddToTable(DBPerson person);
        void UpdateTable(DBPerson person);
        void DeleteFromTable(int id);
    }
}
