using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDealRepository
    {
        List<Deal> GetTable();
        Deal GetConcreteRecord(int id);
        void AddToTable(Deal deal);
        void UpdateTable(Deal updatedDeal);
        void DeleteFromTable(int id);
    }
}
