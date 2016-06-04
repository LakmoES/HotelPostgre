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
    public class StaffRepository : IStaffRepository
    {
        private DBConnection dbc;
        public StaffRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public List<Staff> GetTable(int companyID = -1)
        {
            List<Staff> staffsTable = new List<Staff>();
            Staff staffTbl;

            //try
            //{
            string queryText = "SELECT * FROM \"HomeBUY\".\"Staff\"";
            if (companyID != -1)
                queryText += " WHERE \"id\" = " + companyID.ToString();

            NpgsqlCommand queryCommand = new NpgsqlCommand(queryText, dbc.Connection);
            NpgsqlDataReader staffTableReader = queryCommand.ExecuteReader();

            if (staffTableReader.HasRows)
                foreach (DbDataRecord dbDataRecord in staffTableReader)
                {
                    Application.DoEvents();
                    staffTbl = new Staff(
                        Convert.ToInt32(dbDataRecord["id"]),
                        dbDataRecord["Name"].ToString(),
                        dbDataRecord["Surname"].ToString(),
                        dbDataRecord["Telephone"].ToString(),
                        Convert.ToInt32(dbDataRecord["Company"])
                        );
                    staffsTable.Add(staffTbl);
                }
            staffTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return staffsTable;
        }
        public Staff GetConcreteRecord(int id)
        {
            Staff staffTbl = null;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Staff\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader staffTableReader = queryCommand.ExecuteReader();

                if (staffTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in staffTableReader)
                    {
                        Application.DoEvents();
                        staffTbl = new Staff(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Name"].ToString(),
                            dbDataRecord["Surname"].ToString(),
                            dbDataRecord["Telephone"].ToString(),
                            Convert.ToInt32(dbDataRecord["Company"])
                            );
                        break;
                    }
                staffTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return staffTbl;
        }
        public void AddToTable(Staff staff)
        {
            NpgsqlCommand queryCommand;
            //try
            //{
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Staff\" (\"Name\", \"Surname\", \"Telephone\", \"Company\")" +
                    "VALUES(@Name, @Surname, @Telephone, @Company)", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Name", staff.name);
                queryCommand.Parameters.AddWithValue("@Surname", staff.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", staff.telephone);
                queryCommand.Parameters.AddWithValue("@Company", staff.company);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException)
            //{ }
        }
        public void UpdateTable(Staff staff)
        {
            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Staff\" SET \"Name\" = @Name, \"Surname\" = @Surname, \"Telephone\" = @Telephone, \"Company\" = @Company" +
                    " WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Name", staff.name);
                queryCommand.Parameters.AddWithValue("@Surname", staff.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", staff.telephone);
                queryCommand.Parameters.AddWithValue("@Company", staff.company);
                queryCommand.Parameters.AddWithValue("@id", staff.id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Staff\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
    }
}
