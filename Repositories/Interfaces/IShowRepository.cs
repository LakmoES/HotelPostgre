using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IShowRepository
    {
        List<Show> GetTable();
        Show GetConcreteRecord(int id);
        void AddToTable(Show show);
        void UpdateTable(Show updatedShow);
        void DeleteFromTable(int id);
    }
}
