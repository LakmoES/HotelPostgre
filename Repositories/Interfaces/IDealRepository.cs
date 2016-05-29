using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDealRepository
    {
        List<DBDeal> GetTable();
        DBDeal GetConcreteRecord(int id);
        void AddToTable(DBDeal deal);
        void UpdateTable(DBDeal updatedDeal);
        void DeleteFromTable(int id);
    }
}
