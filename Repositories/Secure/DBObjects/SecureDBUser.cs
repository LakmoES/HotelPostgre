using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SecureDBUser
    {
        public string name;
        public string password;
        public int db_role;
        public int subgroup;
        public SecureDBUser(string name, string password, int db_role, int subgroup)
        {
            this.name = name;
            this.password = password;
            this.db_role = db_role;
            this.subgroup = subgroup;
        }
    }
}
