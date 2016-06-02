using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStaffRepository
    {
        List<Staff> GetTable(int companyID = -1);
        Staff GetConcreteRecord(int id);
        void AddToTable(Staff staff);
        void UpdateTable(Staff staff);
        void DeleteFromTable(int id);
    }
}
