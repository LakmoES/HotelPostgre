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
    public class DealRepository : IDealRepository
    {
        private DBConnection dbc;
        public DealRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public List<Deal> GetTable()
        {
            List<Deal> dealTable = new List<Deal>();
            Deal deal;

                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Deal\"", dbc.Connection);
                NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

                if (dealTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in dealTableReader)
                    {
                        Application.DoEvents();
                        deal = new Deal(
                            Convert.ToInt32(dbDataRecord["id"]),
                            Convert.ToInt32(dbDataRecord["Dealer"]),
                            Convert.ToInt32(dbDataRecord["Buyer"]),
                            Convert.ToInt32(dbDataRecord["Object"]),
                            Convert.ToSingle(dbDataRecord["Cost"]),
                            Convert.ToDateTime(dbDataRecord["Date"])
                            );
                        dealTable.Add(deal);
                    }
                dealTableReader.Close();

            return dealTable;
        }
        public Deal GetConcreteRecord(int id)
        {
            Deal deal = null;
            
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Deal\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

                if (dealTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in dealTableReader)
                    {
                        Application.DoEvents();
                        deal = new Deal(
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

            return deal;
        }
        public void AddToTable(Deal deal)
        {
            NpgsqlCommand queryCommand;

                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Deal\" (\"Dealer\", \"Buyer\", \"Object\", \"Cost\", \"Date\")" +
                    " VALUES(@Dealer, @Buyer, @Object, @Cost, @Date)", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Dealer", deal.dealer);
                queryCommand.Parameters.AddWithValue("@Buyer", deal.buyer);
                queryCommand.Parameters.AddWithValue("@Object", deal.obj);
                queryCommand.Parameters.AddWithValue("@Cost", deal.cost);
                queryCommand.Parameters.AddWithValue("@Date", deal.date);
                queryCommand.ExecuteNonQuery();
        }
        public void UpdateTable(Deal updatedDeal)
        {
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Deal\" SET \"Dealer\" = @Dealer, \"Buyer\" = @Buyer, \"Object\" = @Object, \"Cost\" = @Cost, \"Date\" = @Date" +
                    " WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Dealer", updatedDeal.dealer);
                queryCommand.Parameters.AddWithValue("@Buyer", updatedDeal.buyer);
                queryCommand.Parameters.AddWithValue("@Object", updatedDeal.obj);
                queryCommand.Parameters.AddWithValue("@Cost", updatedDeal.cost);
                queryCommand.Parameters.AddWithValue("@Date", updatedDeal.date);
                queryCommand.Parameters.AddWithValue("@id", updatedDeal.id);
                queryCommand.ExecuteNonQuery();
        }
        public void DeleteFromTable(int id)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Deal\" WHERE \"id\" = @id", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            queryCommand.ExecuteNonQuery();
        }
    }
}
