using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SecureDBRole
    {
        public int role;
        public string name;
        public string password;
        public SecureDBRole(int role, string name, string password)
        {
            this.role = role;
            this.name = name;
            this.password = password;
        }
    }
}
