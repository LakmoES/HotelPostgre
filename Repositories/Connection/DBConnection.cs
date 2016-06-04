using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;

namespace Repositories
{
    public class DBConnection
    {
        private NpgsqlConnection conn = null;
        public DBConnection(NpgsqlConnection conn) { this.conn = conn; }
        public NpgsqlConnection Connection
        {
            get {return conn;}
        }
        public void OpenConnection()
        {
            if (conn == null)
                throw new NullReferenceException("connection is null");
            conn.Open();
        }
        public void CloseConnection()
        {
            if (conn == null)
                throw new NullReferenceException("connection is null");
            conn.Close();
        }
        public void ChangeConnection(NpgsqlConnection newConnection)
        {
            if (conn != null)
                this.CloseConnection();
            conn = newConnection;
        }
    }
}
