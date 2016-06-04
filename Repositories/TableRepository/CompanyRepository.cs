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
    public class CompanyRepository : ICompanyRepository
    {
        DBConnection dbc;
        public CompanyRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public List<Company> GetTable()
        {
            List<Company> companyTable = new List<Company>();
            Company companyTbl;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Company\"", dbc.Connection);
                NpgsqlDataReader companyTableReader = queryCommand.ExecuteReader();

                if (companyTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in companyTableReader)
                    {
                        Application.DoEvents();
                        companyTbl = new Company(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Title"].ToString(),
                            dbDataRecord["Telephone"].ToString(),
                            dbDataRecord["Address"].ToString()
                            );
                        companyTable.Add(companyTbl);
                    }
                companyTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return companyTable;
        }
        public Company GetConcreteRecord(int id)
        {
            Company companyTbl = null;

            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"Company\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader companyTableReader = queryCommand.ExecuteReader();

                if (companyTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in companyTableReader)
                    {
                        Application.DoEvents();
                        companyTbl = new Company(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Title"].ToString(),
                            dbDataRecord["Telephone"].ToString(),
                            dbDataRecord["Address"].ToString()
                            );
                        break;
                    }
                companyTableReader.Close();
            //}
            //catch (NpgsqlException exp)
            //{
            //    MessageBox.Show(Convert.ToString(exp), "Ошибка");
            //}
            return companyTbl;
        }
        public void AddToTable(Company company)
        {
            NpgsqlCommand queryCommand;
            //try
            //{
                //id, Title, Telephone, Address
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"Company\" (\"Title\", \"Telephone\", \"Address\")" +
                    " VALUES(@Title, @Telephone, @Address)", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Title", company.title);
                queryCommand.Parameters.AddWithValue("@Telephone", company.telephone);
                queryCommand.Parameters.AddWithValue("@Address", company.address);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException)
            //{ }
        }
        public void UpdateTable(Company updatedCompany)
        {
            //try
            //{
                //id, Title, Telephone, Address
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"Company\" SET \"Title\" = @Title, \"Telephone\" = @Telephone, \"Address\" = @Address" +
                    " WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Title", updatedCompany.title);
                queryCommand.Parameters.AddWithValue("@Telephone", updatedCompany.telephone);
                queryCommand.Parameters.AddWithValue("@Address", updatedCompany.address);
                queryCommand.Parameters.AddWithValue("@id", updatedCompany.id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            //try
            //{
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"Company\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
            //}
            //catch (NpgsqlException) { }
        }
    }
}
