using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEntityRepository
    {
        List<Entity> GetTable();
        Entity GetConcreteRecord(int id);
        void AddToTable(Entity obj);
        void UpdateTable(Entity objToUpdate);
        void DeleteFromTable(int id);
    }
}
