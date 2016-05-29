using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IWishRepository
    {
        List<DBWish> GetTable();
        DBWish GetConcreteRecord(int id);
        void AddToTable(DBWish wish);
        void UpdateTable(DBWish updatedWish);
        void DeleteFromTable(int id);
    }
}
