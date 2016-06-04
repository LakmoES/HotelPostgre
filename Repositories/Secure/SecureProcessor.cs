using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Repositories
{
    public static class SecureProcessor
    {
        public static bool Login(string name, string password)
        {
            if (!Connect())
                return false;

            var user = SecureUserRepository.GetConcreteRecord(name, SecureCrypt.MD5(password).ToLower());
            if (user == null)
                return false;

            var role = SecureRoleRepository.GetConcreteRecord(user.db_role);

            string db_name = role.name;
            string db_password = SecureCrypt.Decrypt(role.password, SecureConst.cryptKey);

            User.Set(user.name, password, user.db_role, user.subgroup);

            return Reconnect(db_name, db_password);
        }
        private static bool Reconnect(string db_name, string db_password)
        {
            if (DBConnection.Instance.connection != null)
                DBConnection.Instance.closeConnection();

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=" + db_name + ";Password=" + db_password + ";Database=postgres;");
                DBConnection.Instance.setConnection(conn);
                DBConnection.Instance.openConnection();
                return true;
            }
            catch(PostgresException nEx)
            {
                MessageBox.Show(nEx.Message);
                return false;
            }
        }
        private static bool Connect()
        {
            if (DBConnection.Instance.connection != null)
                DBConnection.Instance.closeConnection();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=role_checker;Password=role_checker;Database=postgres;");
                DBConnection.Instance.setConnection(conn);
                DBConnection.Instance.openConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
