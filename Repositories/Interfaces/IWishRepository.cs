using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IWishRepository
    {
        List<Wish> GetTable();
        Wish GetConcreteRecord(int id);
        void AddToTable(Wish wish);
        void UpdateTable(Wish updatedWish);
        void DeleteFromTable(int id);
    }
}
