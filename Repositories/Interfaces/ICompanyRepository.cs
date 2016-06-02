using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetTable();
        Company GetConcreteRecord(int id);
        void AddToTable(Company company);
        void UpdateTable(Company updatedCompany);
        void DeleteFromTable(int id);
    }
}
