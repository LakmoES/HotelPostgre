﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using Npgsql;

namespace Repositories
{
    public class WishRepository : IWishRepository
    {
        private DBConnection dbc;
        public WishRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        private object FixDBValue(object value)
        {
            if (value is DBNull)
                return null;
            return value;
        }
        public List<Wish> GetTable()
        {
            List<Wish> wishTable = new List<Wish>();
            Wish wish;
            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Wish\"", dbc.Connection);
            NpgsqlDataReader wishTableReader = queryCommand.ExecuteReader();

            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            if (wishTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in wishTableReader)
                {
                    Application.DoEvents();
                    wish = new Wish(
                        Convert.ToInt32(dbDataRecord["id"]),
                        Convert.ToInt32(dbDataRecord["Client"]),
                        (FixDBValue(dbDataRecord["Township"]) ?? "").ToString(), // is null ? => empty
                        (FixDBValue(dbDataRecord["ApartmentOrHouse"]) ?? "").ToString(),
                        Convert.ToSingle(FixDBValue(dbDataRecord["Area"])),
                        Convert.ToInt32(FixDBValue(dbDataRecord["NumberOfRooms"])),
                        Convert.ToSingle(FixDBValue(dbDataRecord["Cost"]))
                        );
                    wishTable.Add(wish);
                }
            wishTableReader.Close();

            return wishTable;
        }
        public Wish GetConcreteRecord(int id)
        {
            Wish wish = null;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Wish\" WHERE \"id\" = @id", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader wishTableReader = queryCommand.ExecuteReader();

            if (wishTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in wishTableReader)
                {
                    Application.DoEvents();
                    wish = new Wish(
                        Convert.ToInt32(dbDataRecord["id"]),
                        Convert.ToInt32(dbDataRecord["Client"]),
                        (FixDBValue(dbDataRecord["Township"]) ?? "").ToString(),   // is null ? => empty
                        (FixDBValue(dbDataRecord["ApartmentOrHouse"]) ?? "").ToString(),
                        Convert.ToInt32(FixDBValue(dbDataRecord["Area"])),
                        Convert.ToInt32(FixDBValue(dbDataRecord["NumberOfRooms"])),
                        Convert.ToInt32(FixDBValue(dbDataRecord["Cost"]))
                        );
                    break;
                }
            wishTableReader.Close();

            return wish;
        }
        public void AddToTable(Wish wish)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            NpgsqlCommand queryCommand;
            queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Wish\" (\"Client\", \"Township\", \"ApartmentOrHouse\", \"Area\", \"NumberOfRooms\", \"Cost\")" +
                " VALUES(@Client, @Township, @ApartamentOrHouse, @Area, @NumberOfRooms, @Cost)", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@Client", wish.client );
            queryCommand.Parameters.AddWithValue("@Township", (wish.township ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@ApartamentOrHouse", (wish.apartamentOrHouse ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@Area", (wish.area ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@NumberOfRooms", (wish.numberOfRooms ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@Cost", (wish.cost ?? (object)DBNull.Value));
            queryCommand.ExecuteNonQuery();

        }
        public void UpdateTable(Wish updatedWish)
        {
            //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
            NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Wish\" SET \"Client\" = @Client, \"Township\" = @Township, \"ApartmentOrHouse\" = @ApartamentOrHouse, \"Area\" = @Area, \"NumberOfRooms\" = @NumberOfRooms, \"Cost\" = @Cost" +
                " WHERE \"id\" = @id", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@Client", updatedWish.client);
            queryCommand.Parameters.AddWithValue("@Township", (updatedWish.township ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@ApartamentOrHouse", (updatedWish.apartamentOrHouse ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@Area", (updatedWish.area ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@NumberOfRooms", (updatedWish.numberOfRooms ?? (object)DBNull.Value));
            queryCommand.Parameters.AddWithValue("@Cost", (updatedWish.cost ?? (object)DBNull.Value));

            queryCommand.Parameters.AddWithValue("@id", updatedWish.id);
            queryCommand.ExecuteNonQuery();

        }
        public void DeleteFromTable(int id)
        {
            NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Wish\" WHERE \"id\" = @id", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@id", id);
            queryCommand.ExecuteNonQuery();
        }
    }
}
