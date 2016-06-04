﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private DBConnection dbc;
        public ObjectRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public List<Entity> GetTable()
        {
            List<Entity> objectsTable = new List<Entity>();
            Entity objectTbl;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Object\"", dbc.Connection);
                NpgsqlDataReader ObjectTableReader = queryCommand.ExecuteReader();

                if (ObjectTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in ObjectTableReader)
                    {
                        Application.DoEvents();
                        objectTbl = new Entity(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Address"].ToString(),
                            Convert.ToDateTime(dbDataRecord["AddDate"])/*DateTime.Now*/,
                            //parseCost(dbDataRecord["Cost"].ToString()),
                            Convert.ToSingle(dbDataRecord["Cost"]),
                            Convert.ToInt32(dbDataRecord["Owner"]),
                            dbDataRecord["AppartamentOrHouse"].ToString(),
                            Convert.ToSingle(dbDataRecord["Area"]),
                            Convert.ToInt32(dbDataRecord["NumberOfRooms"])
                            );
                        objectsTable.Add(objectTbl);
                    }
                ObjectTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return objectsTable;
        }
        public Entity GetConcreteRecord(int id)
        {
            Entity objectTbl = null;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Object\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader ObjectTableReader = queryCommand.ExecuteReader();

                if (ObjectTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in ObjectTableReader)
                    {
                        Application.DoEvents();
                        objectTbl = new Entity(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Address"].ToString(),
                            Convert.ToDateTime(dbDataRecord["AddDate"]),
                            Convert.ToSingle(dbDataRecord["Cost"]),
                            Convert.ToInt32(dbDataRecord["Owner"]),
                            dbDataRecord["AppartamentOrHouse"].ToString(),
                            Convert.ToSingle(dbDataRecord["Area"]),
                            Convert.ToInt32(dbDataRecord["NumberOfRooms"])
                            );
                        break;
                    }
                ObjectTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return objectTbl;
        }
        public void AddToTable(Entity obj)
        {
            NpgsqlCommand queryCommand;
            //try
            //{
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Object\" (\"Address\", \"AddDate\", \"Cost\", \"Owner\", \"AppartamentOrHouse\", \"Area\", \"NumberOfRooms\")"+
                    "VALUES(@Address, @AddDate, @Cost, @Owner, @AppartamentOrHouse, @Area, @NumberOfRooms)", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Address", obj.address);
                queryCommand.Parameters.AddWithValue("@AddDate", obj.addDate);
                queryCommand.Parameters.AddWithValue("@Cost", obj.cost);
                queryCommand.Parameters.AddWithValue("@Owner", obj.owner);
                queryCommand.Parameters.AddWithValue("@AppartamentOrHouse", obj.appartamentOrHouse);
                queryCommand.Parameters.AddWithValue("@Area", obj.area);
                queryCommand.Parameters.AddWithValue("@NumberOfRooms", obj.numberOfRooms);
                queryCommand.ExecuteNonQuery();
            //}
            //catch(NpgsqlException)
            //{ }
        }
        public void UpdateTable(Entity objToUpdate)
        {
            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Object\" SET \"Address\" = @Address, \"AddDate\" = @AddDate, \"Cost\" = @Cost, \"Owner\" = @Owner, \"AppartamentOrHouse\" = @AppartamentOrHouse, \"Area\" = @Area, \"NumberOfRooms\" = @NumberOfRooms" +
                    " WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Address", objToUpdate.address);
                queryCommand.Parameters.AddWithValue("@AddDate", objToUpdate.addDate);
                queryCommand.Parameters.AddWithValue("@Cost", objToUpdate.cost);
                queryCommand.Parameters.AddWithValue("@Owner", objToUpdate.owner);
                queryCommand.Parameters.AddWithValue("@AppartamentOrHouse", objToUpdate.appartamentOrHouse);
                queryCommand.Parameters.AddWithValue("@Area", objToUpdate.area);
                queryCommand.Parameters.AddWithValue("@NumberOfRooms", objToUpdate.numberOfRooms);
                queryCommand.Parameters.AddWithValue("@id", objToUpdate.id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Object\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
    }
}
