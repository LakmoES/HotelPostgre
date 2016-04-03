using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DataAccessLayer
{
    class SQLProcessor
    {
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

        public void testRead(/*DataGridView dataGridView*/)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=root;Database=Shmelyov;");
            conn.Open();

            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand("select \"HomeBUY\".\"Deal\".\"Dealer\" from \"HomeBUY\".\"Deal\"", conn);

            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();

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
