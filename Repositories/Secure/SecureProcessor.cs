using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Repositories
{
    public class SecureProcessor
    {
        public SecureProcessor()
        {
        }
        public bool Login(string name, string password)
        {
            Connect();

            var user = SecureUserRepository.GetConcreteRecord(name, SecureCrypt.MD5(password).ToLower());
            if (user == null)
                return false;

            var role = SecureRoleRepository.GetConcreteRecord(user.db_role);

            string db_name = role.name;
            string db_password = SecureCrypt.Decrypt(role.password, SecureConst.sha1Key);

            User.Set(user.name, user.db_role, user.subrole);

            return Reconnect(db_name, db_password);
        }
        private bool Reconnect(string db_name, string db_password)
        {
            Connect();

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
        private bool Connect()
        {
            if (DBConnection.Instance.connection != null)
                DBConnection.Instance.closeConnection();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=role_checker;Password=role_checker;Database=roles;");
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
