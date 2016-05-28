using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;

namespace Repositories
{
    public class ShowRepository
    {
        public ShowRepository() { }
        public List<DBShow> GetTable()
        {
            List<DBShow> showTable = new List<DBShow>();
            DBShow showTbl;
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Show\"", DBConnection.Instance.connection);
                NpgsqlDataReader showTableReader = queryCommand.ExecuteReader();

                if (showTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in showTableReader)
                    {
                        Application.DoEvents();
                        showTbl = new DBShow(
                            Convert.ToInt32(dbDataRecord["id"]),
                            Convert.ToInt32(dbDataRecord["Dealer"]),
                            Convert.ToInt32(dbDataRecord["Client"]),
                            Convert.ToInt32(dbDataRecord["Object"]),
                            Convert.ToDateTime(dbDataRecord["Date"])
                            );
                        showTable.Add(showTbl);
                    }
                showTableReader.Close();

            return showTable;
        }
        public DBShow GetConcreteRecord(int id)
        {
            DBShow showTbl = null;
            
            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Show\" WHERE \"id\" = @id", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader showTableReader = queryCommand.ExecuteReader();

            if (showTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in showTableReader)
                {
                    Application.DoEvents();
                    showTbl = new DBShow(
                        Convert.ToInt32(dbDataRecord["id"]),
                        Convert.ToInt32(dbDataRecord["Dealer"]),
                        Convert.ToInt32(dbDataRecord["Client"]),
                        Convert.ToInt32(dbDataRecord["Object"]),
                        Convert.ToDateTime(dbDataRecord["Date"])
                        );
                    break;
                }
            showTableReader.Close();
           
            return showTbl;
        }
        public void AddToTable(DBShow show)
        {
            NpgsqlCommand queryCommand;
            queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Show\" (\"Dealer\", \"Client\", \"Object\", \"Date\")" +
                " VALUES(@Dealer, @Client, @Object, @Date)", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@Dealer", show.dealer);
            queryCommand.Parameters.AddWithValue("@Client", show.client);
            queryCommand.Parameters.AddWithValue("@Object", show.obj);
            queryCommand.Parameters.AddWithValue("@Date", show.date);
            queryCommand.ExecuteNonQuery();
            
        }
        public void UpdateTable(DBShow updatedShow)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Show\" SET \"Dealer\" = @Dealer, \"Client\" = @Client, \"Object\" = @Object, \"Date\" = @Date" +
                " WHERE \"id\" = @id", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@Dealer", updatedShow.dealer);
            queryCommand.Parameters.AddWithValue("@Client", updatedShow.client);
            queryCommand.Parameters.AddWithValue("@Object", updatedShow.obj);
            queryCommand.Parameters.AddWithValue("@Date", updatedShow.date);
            queryCommand.Parameters.AddWithValue("@id", updatedShow.id);
            queryCommand.ExecuteNonQuery();
            
        }
        public void DeleteFromTable(int id)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Show\" WHERE \"id\" = @id", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            queryCommand.ExecuteNonQuery();
        }
    }
}
