using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace Repositories
{
    public class ObjectRepository
    {
        //private DBConnection dbc;

        public ObjectRepository(/*DBConnection dbc*/)
        {
            //this.dbc = dbc;
        }

        public List<DBObject> GetTable()
        {
            List<DBObject> objectsTable = new List<DBObject>();
            DBObject objectTbl;

            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Object\"", DBConnection.Instance.connection);
                NpgsqlDataReader ObjectTableReader = queryCommand.ExecuteReader();

                if (ObjectTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in ObjectTableReader)
                    {
                        Application.DoEvents();
                        objectTbl = new DBObject(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Address"].ToString(),
                            Convert.ToDateTime(dbDataRecord["AddDate"])/*DateTime.Now*/,
                            //parseCost(dbDataRecord["Cost"].ToString()),
                            Convert.ToInt32(dbDataRecord["Cost"].ToString()),
                            Convert.ToInt32(dbDataRecord["Owner"]),
                            dbDataRecord["AppartamentOrHouse"].ToString(),
                            Convert.ToInt32(dbDataRecord["Area"]),
                            Convert.ToInt32(dbDataRecord["NumberOfRooms"])
                            );
                        objectsTable.Add(objectTbl);
                    }
                ObjectTableReader.Close();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp), "Ошибка");
            }
            return objectsTable;
        }
        //private static Money parseCost(string s)
        //{
        //    string ammount = "";
        //    string currency = "";
        //    bool searchForAmmount = true;
        //    foreach (char c in s)
        //    {
        //        if (c == ',')
        //            searchForAmmount = false;
        //        if (searchForAmmount && c >= '0' && c <= '9')
        //            ammount += c;
        //        else if (!searchForAmmount && c != ' ' && c != ',')
        //            currency += c;
        //    }
        //    return new Money(Convert.ToInt32(ammount), currency);
        //}
        public void AddToTable(DBObject obj)
        {
            NpgsqlCommand queryCommand;
            try
            {
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Object\" (\"Address\", \"AddDate\", \"Cost\", \"Owner\", \"AppartamentOrHouse\", \"Area\", \"NumberOfRooms\")"+
                    "VALUES(@Address, @AddDate, @Cost, @Owner, @AppartamentOrHouse, @Area, @NumberOfRooms)", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Address", obj.address);
                queryCommand.Parameters.AddWithValue("@AddDate", obj.addDate);
                queryCommand.Parameters.AddWithValue("@Cost", obj.cost);
                queryCommand.Parameters.AddWithValue("@Owner", obj.owner);
                queryCommand.Parameters.AddWithValue("@AppartamentOrHouse", obj.appartamentOrHouse);
                queryCommand.Parameters.AddWithValue("@Area", obj.area);
                queryCommand.Parameters.AddWithValue("@NumberOfRooms", obj.numberOfRooms);
                queryCommand.ExecuteNonQuery();
            }
            catch(NpgsqlException)
            { }
        }
        public void UpdateTable(DBObject objToUpdate)
        {
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Object\" SET \"Address\" = @Address, \"AddDate\" = @AddDate, \"Cost\" = @Cost, \"Owner\" = @Owner, \"AppartamentOrHouse\" = @AppartamentOrHouse, \"Area\" = @Area, \"NumberOfRooms\" = @NumberOfRooms" +
                    " WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Address", objToUpdate.address);
                queryCommand.Parameters.AddWithValue("@AddDate", objToUpdate.addDate);
                queryCommand.Parameters.AddWithValue("@Cost", objToUpdate.cost);
                queryCommand.Parameters.AddWithValue("@Owner", objToUpdate.owner);
                queryCommand.Parameters.AddWithValue("@AppartamentOrHouse", objToUpdate.appartamentOrHouse);
                queryCommand.Parameters.AddWithValue("@Area", objToUpdate.area);
                queryCommand.Parameters.AddWithValue("@NumberOfRooms", objToUpdate.numberOfRooms);
                queryCommand.Parameters.AddWithValue("@id", objToUpdate.id);
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Object\" WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException) { }
        }
    }
}
