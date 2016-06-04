using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class User
    {
        public static string name { private set; get; }
        //public static string password { private set; get; }
        public static int role { private set; get; }
        public static int subgroup { private set; get; }
        public static void Set(string name/*, string password*/, int role, int subgroup)
        {
            User.name = name;
            //User.password = password;
            User.role = role;
            User.subgroup = subgroup;
        }
    }
}
