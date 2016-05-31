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
        public static List<SecureDBUser> GetTable()
        {
            List<SecureDBUser> userTable = new List<SecureDBUser>();
            SecureDBUser userTbl = null;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"public\".\"User\"", DBConnection.Instance.connection);
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
                    userTable.Add(userTbl);
                }
            userTableReader.Close();
            return userTable;
        }
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
        public static void AddToTable(SecureDBUser user)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            NpgsqlCommand queryCommand;
            queryCommand = new NpgsqlCommand("INSERT INTO \"public\".\"User\" (\"name\", \"password\", \"db_role\", \"sub_role\")" +
                " VALUES(@name, @password, @db_role, @sub_role)", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@name", user.name);
            queryCommand.Parameters.AddWithValue("@password", user.password);
            queryCommand.Parameters.AddWithValue("@db_role", user.db_role);
            queryCommand.Parameters.AddWithValue("@sub_role", user.subrole);
            queryCommand.ExecuteNonQuery();
        }
        public static void UpdateTable(SecureDBUser user)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"public\".\"User\" SET \"password\" = @password, \"db_role\" = @db_role, \"sub_role\" = @sub_role" +
                " WHERE \"name\" = @name", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@password", user.password);
            queryCommand.Parameters.AddWithValue("@db_role", user.db_role);
            queryCommand.Parameters.AddWithValue("@sub_role", user.subrole);

            queryCommand.Parameters.AddWithValue("@name", user.name);
            queryCommand.ExecuteNonQuery();

        }
        public static void DeleteFromTable(string name)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"public\".\"User\" WHERE \"name\" = @name", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@name", name);
            queryCommand.ExecuteNonQuery();
        }
    }
}
