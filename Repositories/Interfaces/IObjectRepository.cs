using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IObjectRepository
    {
        List<DBObject> GetTable();
        DBObject GetConcreteRecord(int id);
        void AddToTable(DBObject obj);
        void UpdateTable(DBObject objToUpdate);
        void DeleteFromTable(int id);
    }
}
