using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICompanyRepository
    {
        List<DBCompany> GetTable();
        DBCompany GetConcreteRecord(int id);
        void AddToTable(DBCompany company);
        void UpdateTable(DBCompany updatedCompany);
        void DeleteFromTable(int id);
    }
}
