using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;

namespace Repositories
{
    public class SecureUserRepository
    {
        public static SecureDBUser GetConcreteRecord(string name, string password)
        {
            SecureDBUser userTbl = null;
            
            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"public\".\"User\" WHERE \"name\" = @name AND \"password\" = @password", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@name", name);
            queryCommand.Parameters.AddWithValue("@password", password);
            NpgsqlDataReader userTableReader = queryCommand.ExecuteReader();

            if (userTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in userTableReader)
                {
                    userTbl = new SecureDBUser(
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["password"].ToString(),
                        Convert.ToInt32(dbDataRecord["db_role"]),
                        Convert.ToInt32(dbDataRecord["sub_role"])
                        );
                    break;
                }
            userTableReader.Close();
            return userTbl;
        }
    }
}
