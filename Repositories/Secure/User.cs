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
        public static string password { private set; get; }
        public static int role { private set; get; }
        public static int subrole { private set; get; }
        public static void Set(string name_, string password_, int role_, int subrole_)
        {
            name = name_;
            password = password_;
            role = role_;
            subrole = subrole_;
        }
    }
}
