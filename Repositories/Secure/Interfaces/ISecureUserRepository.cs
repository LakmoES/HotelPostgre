using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISecureUserRepository
    {
        List<SecureDBUser> GetTable();
        SecureDBUser GetConcreteRecord(string name, string password);
        void AddToTable(SecureDBUser user);
        void UpdateTable(SecureDBUser user);
        void DeleteFromTable(string name);
    }
}
