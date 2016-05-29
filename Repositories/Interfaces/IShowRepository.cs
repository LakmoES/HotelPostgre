using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IShowRepository
    {
        List<DBShow> GetTable();
        DBShow GetConcreteRecord(int id);
        void AddToTable(DBShow show);
        void UpdateTable(DBShow updatedShow);
        void DeleteFromTable(int id);
    }
}
