using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;

namespace DataAccessLayer
{
    class SQLProcessor
    {
        private NpgsqlConnection conn;

        private static SQLProcessor instance;
        private SQLProcessor() { }
        public static SQLProcessor Instance
        {
            get
            {
                if (instance == null)
                    instance = new SQLProcessor();
                return instance;
            }
        }

        public void connect(string username, string password)
        {
            //username = postgres
            //password = root
            conn = new NpgsqlConnection(String.Format("Server=127.0.0.1;User Id={0};Password={1};Database=Shmelyov;", username, password));
            //conn.Open();
        }
        public void disconnect()
        {
            //conn = null;
            conn.Close();
        }
        public int executeWOResult(string queryText)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(queryText, conn);
            // Execute a query
            var numberOfRows = cmd.ExecuteNonQuery();
            conn.Close();
            return numberOfRows;
        }
        public NpgsqlDataReader executeWResult(string queryText)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(queryText, conn);
            // Execute a query
            conn.Open();
            var rd = cmd.ExecuteReader();
            MessageBox.Show("hr"+rd.HasRows.ToString());
            //conn.Close();
            return rd;
        }
        public void testRead(/*DataGridView dataGridView*/)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=root;Database=Shmelyov;");
            conn.Open();

            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand("select \"HomeBUY\".\"Deal\".\"Dealer\" from \"HomeBUY\".\"Deal\"", conn);

            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("dr" + dr.FieldCount);
            // Read all rows and output the first column in each row

            /*dataGridView.Rows.Clear();

            if (dr.HasRows)
                foreach (DbDataRecord dbDaraRecord in dr)
                {
                    dataGridView.Rows.Add(dbDaraRecord["Dealer"].ToString());
                }*/

            // Close connection
            conn.Close();
        }
    }
}
