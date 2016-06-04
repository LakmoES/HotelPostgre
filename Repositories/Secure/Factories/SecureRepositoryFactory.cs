using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SecureRepositoryFactory : ISecureRepositoryFactory
    {
        private DBConnection dbc;
        public SecureRepositoryFactory(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public ISecureRoleRepository GetSecureRoleRepository()
        {
            return new SecureRoleRepository(dbc);
        }
        public ISecureUserRepository GetSecureUserRepository()
        {
            return new SecureUserRepository(dbc);
        }
    }
}
