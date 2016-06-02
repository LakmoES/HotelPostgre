using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetTable();
        Person GetConcreteRecord(int id);
        void AddToTable(Person person);
        void UpdateTable(Person person);
        void DeleteFromTable(int id);
    }
}
