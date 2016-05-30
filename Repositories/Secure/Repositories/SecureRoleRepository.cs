using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;

namespace Repositories
{
    public class SecureRoleRepository
    {
        public static SecureDBRole GetConcreteRecord(int role)
        {
            SecureDBRole roleTbl = null;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"public\".\"Role\" WHERE \"role\" = @role", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@role", role);
            NpgsqlDataReader roleTableReader = queryCommand.ExecuteReader();

            if (roleTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in roleTableReader)
                {
                    roleTbl = new SecureDBRole(
                        Convert.ToInt32(dbDataRecord["role"]),
                        dbDataRecord["db_user"].ToString(),
                        dbDataRecord["db_password"].ToString()
                        );
                    break;
                }
            roleTableReader.Close();
            return roleTbl;
        }
    }
}
