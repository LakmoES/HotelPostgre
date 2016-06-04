using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;

namespace Repositories
{
    public class SecureUserRepository : ISecureUserRepository
    {
        private DBConnection dbc;
        public SecureUserRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public List<SecureDBUser> GetTable()
        {
            List<SecureDBUser> userTable = new List<SecureDBUser>();
            SecureDBUser userTbl = null;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"login\".\"User\"", dbc.Connection);
            NpgsqlDataReader userTableReader = queryCommand.ExecuteReader();

            if (userTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in userTableReader)
                {
                    userTbl = new SecureDBUser(
                        dbDataRecord["name"].ToString(),
                        dbDataRecord["password"].ToString(),
                        Convert.ToInt32(dbDataRecord["db_role"]),
                        Convert.ToInt32(dbDataRecord["subgroup"])
                        );
                    userTable.Add(userTbl);
                }
            userTableReader.Close();
            return userTable;
        }
        public SecureDBUser GetConcreteRecord(string name, string password)
        {
            SecureDBUser userTbl = null;
            
            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"login\".\"User\" WHERE \"name\" = @name AND \"password\" = @password", dbc.Connection);
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
                        Convert.ToInt32(dbDataRecord["subgroup"])
                        );
                    break;
                }
            userTableReader.Close();
            return userTbl;
        }
        public void AddToTable(SecureDBUser user)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            NpgsqlCommand queryCommand;
            queryCommand = new NpgsqlCommand("INSERT INTO \"login\".\"User\" (\"name\", \"password\", \"db_role\", \"subgroup\")" +
                " VALUES(@name, @password, @db_role, @subgroup)", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@name", user.name);
            queryCommand.Parameters.AddWithValue("@password", user.password);
            queryCommand.Parameters.AddWithValue("@db_role", user.db_role);
            queryCommand.Parameters.AddWithValue("@subgroup", user.subgroup);
            queryCommand.ExecuteNonQuery();
        }
        public void UpdateTable(SecureDBUser user)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            string queryText = "UPDATE \"login\".\"User\" SET \"password\" = @password, \"db_role\" = @db_role, \"subgroup\" = @subgroup" +
                " WHERE \"name\" = @name";
            if (user.password.Length == 0)
                queryText = "UPDATE \"login\".\"User\" SET \"db_role\" = @db_role, \"subgroup\" = @subgroup" +
                " WHERE \"name\" = @name";
            NpgsqlCommand queryCommand = new NpgsqlCommand(queryText, dbc.Connection);

            if (user.password.Length != 0)
                queryCommand.Parameters.AddWithValue("@password", user.password);

            queryCommand.Parameters.AddWithValue("@db_role", user.db_role);
            queryCommand.Parameters.AddWithValue("@subgroup", user.subgroup);

            queryCommand.Parameters.AddWithValue("@name", user.name);
            queryCommand.ExecuteNonQuery();

        }
        public void DeleteFromTable(string name)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"login\".\"User\" WHERE \"name\" = @name", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@name", name);
            queryCommand.ExecuteNonQuery();
        }
    }
}
