using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStaffRepository
    {
        List<DBStaff> GetTable();
        DBStaff GetConcreteRecord(int id);
        void AddToTable(DBStaff staff);
        void UpdateTable(DBStaff staff);
        void DeleteFromTable(int id);
    }
}
