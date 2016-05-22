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
    public class PersonRepository
    {
        string tableName;
        public PersonRepository(string tableName)
        {
            this.tableName = tableName;
        }
        public List<DBPerson> GetTable()
        {
            List<DBPerson> personsTable = new List<DBPerson>();
            DBPerson personTbl;

            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"" + tableName + "\"", DBConnection.Instance.connection);
                NpgsqlDataReader personTableReader = queryCommand.ExecuteReader();

                if (personTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in personTableReader)
                    {
                        Application.DoEvents();
                        personTbl = new DBPerson(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Name"].ToString(),
                            dbDataRecord["Surname"].ToString(),
                            dbDataRecord["Telephone"].ToString()
                            );
                        personsTable.Add(personTbl);
                    }
                personTableReader.Close();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp), "Ошибка");
            }
            return personsTable;
        }
        public DBPerson GetConcreteRecord(int id)
        {
            DBPerson personTbl = null;

            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"" + tableName + "\" WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader personTableReader = queryCommand.ExecuteReader();

                if (personTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in personTableReader)
                    {
                        Application.DoEvents();
                        personTbl = new DBPerson(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Name"].ToString(),
                            dbDataRecord["Surname"].ToString(),
                            dbDataRecord["Telephone"].ToString()
                            );
                        break;
                    }
                personTableReader.Close();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp), "Ошибка");
            }
            return personTbl;
        }
        public void AddToTable(DBPerson person)
        {
            NpgsqlCommand queryCommand;
            try
            {
                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"" + tableName + "\" (\"Name\", \"Surname\", \"Telephone\")" +
                    "VALUES(@Name, @Surname, @Telephone)", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Name", person.name);
                queryCommand.Parameters.AddWithValue("@Surname", person.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", person.telephone);
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException)
            { }
        }
        public void UpdateTable(DBPerson person)
        {
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"" + tableName + "\" SET \"Name\" = @Name, \"Surname\" = @Surname, \"Telephone\" = @Telephone" +
                    " WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@Name", person.name);
                queryCommand.Parameters.AddWithValue("@Surname", person.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", person.telephone);
                queryCommand.Parameters.AddWithValue("@id", person.id);
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException) { }
        }
        public void DeleteFromTable(int id)
        {
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"" + tableName + "\" WHERE \"id\" = @id", DBConnection.Instance.connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException) { }
        }
    }
}
