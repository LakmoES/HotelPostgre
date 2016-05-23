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
    public class DealRepository
    {
        public DealRepository() { }
        public List<DBDeal> GetTable()
        {
            List<DBDeal> dealTable = new List<DBDeal>();
            DBDeal dealTbl;
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Deal\"", DBConnection.Instance.connection);
                NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

                if (dealTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in dealTableReader)
                    {
                        Application.DoEvents();
                        dealTbl = new DBDeal(
                            Convert.ToInt32(dbDataRecord["id"]),
                            Convert.ToInt32(dbDataRecord["Dealer"]),
                            Convert.ToInt32(dbDataRecord["Buyer"]),
                            Convert.ToInt32(dbDataRecord["Object"]),
                            Convert.ToInt32(dbDataRecord["Cost"]),
                            Convert.ToDateTime(dbDataRecord["Date"])
                            );
                        dealTable.Add(dealTbl);
                    }
                dealTableReader.Close();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp), "Ошибка");
            }
            return dealTable;
        }
        public DBDeal GetConcreteRecord(int id)
        {
            DBDeal dealTbl = null;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Deal\" WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

                if (dealTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in dealTableReader)
                    {
                        Application.DoEvents();
                        dealTbl = new DBDeal(
                            Convert.ToInt32(dbDataRecord["id"]),
                            Convert.ToInt32(dbDataRecord["Dealer"]),
                            Convert.ToInt32(dbDataRecord["Buyer"]),
                            Convert.ToInt32(dbDataRecord["Object"]),
                            Convert.ToInt32(dbDataRecord["Cost"]),
                            Convert.ToDateTime(dbDataRecord["Date"])
                            );
                        break;
                    }
                dealTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return dealTbl;
        }
        public void AddToTable(DBDeal deal)
        {
            NpgsqlCommand queryCommand;
            //try
            //{
                //id, Title, Telephone, Address
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Deal\" (\"Dealer\", \"Buyer\", \"Object\", \"Cost\", \"Date\")" +
                    " VALUES(@Dealer, @Buyer, @Object, @Cost, @Date)", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Dealer", deal.dealer);
                queryCommand.Parameters.AddWithValue("@Buyer", deal.buyer);
                queryCommand.Parameters.AddWithValue("@Object", deal.obj);
                queryCommand.Parameters.AddWithValue("@Cost", deal.cost);
                queryCommand.Parameters.AddWithValue("@Date", deal.date);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException)
            //{ }
        }
        public void UpdateTable(DBDeal updatedDeal)
        {
            //try
            //{
                //id, Title, Telephone, Address
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Deal\" SET \"Dealer\" = @Dealer, \"Buyer\" = @Buyer, \"Object\" = @Object, \"Cost\" = @Cost, \"Date\" = @Date" +
                    " WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Dealer", updatedDeal.dealer);
                queryCommand.Parameters.AddWithValue("@Buyer", updatedDeal.buyer);
                queryCommand.Parameters.AddWithValue("@Object", updatedDeal.obj);
                queryCommand.Parameters.AddWithValue("@Cost", updatedDeal.cost);
                queryCommand.Parameters.AddWithValue("@Date", updatedDeal.date);
                queryCommand.Parameters.AddWithValue("@id", updatedDeal.id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            //try
            //{
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Deal\" WHERE \"id\" = @id", DBConnection.Instance.connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
    }
}
