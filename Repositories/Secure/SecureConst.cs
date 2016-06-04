using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class SecureConst
    {
        public const string cryptKey = "DefaultK";
        private static readonly string[] roleList = { "Unknown", "Administrator", "Director", "Staff" };
        public static string GetRoleName(int roleID)
        {
            return roleList[roleID];
        }
        public static int GetRoleID(string roleName)
        {
            int roleID = -1;
            foreach (string r in roleList)
            {
                ++roleID;
                if (roleName == r)
                    return roleID;
            }
            throw new KeyNotFoundException("Role cannot be found");
        }
    }
}
