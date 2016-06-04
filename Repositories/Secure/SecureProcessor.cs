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
        private DBConnection dbc;
        private ISecureUserRepository secureUserRepository;
        private ISecureRoleRepository secureRoleRepository;
        private string loginUser, loginPassword;
        public SecureProcessor(DBConnection dbc, ISecureRepositoryFactory secureRepositoryFactory, string loginUser, string loginPassword)
        {
            this.dbc = dbc;
            this.secureUserRepository = secureRepositoryFactory.GetSecureUserRepository();
            this.secureRoleRepository = secureRepositoryFactory.GetSecureRoleRepository();
            this.loginUser = loginUser;
            this.loginPassword = loginPassword;
        }
        public bool Login(string name, string password)
        {
            if (!Connect())
                return false;

            var user = secureUserRepository.GetConcreteRecord(name, SecureCrypt.MD5(password).ToLower());
            if (user == null)
                return false;

            var role = secureRoleRepository.GetConcreteRecord(user.db_role);

            string db_name = role.name;
            string db_password = SecureCrypt.DESDecrypt(role.password, SecureConst.cryptKey);

            User.Set(user.name/*, password*/, user.db_role, user.subgroup);

            return Reconnect(db_name, db_password);
        }
        private bool Reconnect(string db_name, string db_password)
        {
            if (dbc.Connection != null)
                dbc.CloseConnection();

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=" + db_name + ";Password=" + db_password + ";Database=postgres;");
                dbc.ChangeConnection(conn);
                dbc.OpenConnection();
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
            if (dbc.Connection != null)
                dbc.CloseConnection();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id="+loginUser+";Password="+loginPassword+";Database=postgres;");
                dbc.ChangeConnection(conn);
                dbc.OpenConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
