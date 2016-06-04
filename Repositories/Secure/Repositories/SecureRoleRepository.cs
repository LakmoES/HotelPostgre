using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;

namespace Repositories
{
    public class SecureRoleRepository : ISecureRoleRepository
    {
        private DBConnection dbc;
        public SecureRoleRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public SecureDBRole GetConcreteRecord(int role)
        {
            SecureDBRole roleTbl = null;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"login\".\"Role\" WHERE \"role\" = @role", dbc.Connection);
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
