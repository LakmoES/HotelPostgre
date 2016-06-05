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
    public class PersonRepository : IPersonRepository
    {
        private DBConnection dbc;
        private string tableName;
        public PersonRepository(DBConnection dbc, string tableName)
        {
            this.dbc = dbc;
            this.tableName = tableName;
        }
        public List<Person> GetTable()
        {
            List<Person> personsTable = new List<Person>();
            Person person;

                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"" + tableName + "\"", dbc.Connection);
                NpgsqlDataReader personTableReader = queryCommand.ExecuteReader();

                if (personTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in personTableReader)
                    {
                        Application.DoEvents();
                        person = new Person(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Name"].ToString(),
                            dbDataRecord["Surname"].ToString(),
                            dbDataRecord["Telephone"].ToString()
                            );
                        personsTable.Add(person);
                    }
                personTableReader.Close();
            return personsTable;
        }
        public Person GetConcreteRecord(int id)
        {
            Person person = null;

                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".\"" + tableName + "\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader personTableReader = queryCommand.ExecuteReader();

                if (personTableReader.HasRows)
                    foreach (DbDataRecord dbDataRecord in personTableReader)
                    {
                        Application.DoEvents();
                        person = new Person(
                            Convert.ToInt32(dbDataRecord["id"]),
                            dbDataRecord["Name"].ToString(),
                            dbDataRecord["Surname"].ToString(),
                            dbDataRecord["Telephone"].ToString()
                            );
                        break;
                    }
                personTableReader.Close();
            return person;
        }
        public void AddToTable(Person person)
        {
            NpgsqlCommand queryCommand;

                queryCommand = new NpgsqlCommand("INSERT INTO \"HomeBUY\".\"" + tableName + "\" (\"Name\", \"Surname\", \"Telephone\")" +
                    "VALUES(@Name, @Surname, @Telephone)", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Name", person.name);
                queryCommand.Parameters.AddWithValue("@Surname", person.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", person.telephone);
                queryCommand.ExecuteNonQuery();
        }
        public void UpdateTable(Person person)
        {
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"HomeBUY\".\"" + tableName + "\" SET \"Name\" = @Name, \"Surname\" = @Surname, \"Telephone\" = @Telephone" +
                    " WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@Name", person.name);
                queryCommand.Parameters.AddWithValue("@Surname", person.surname);
                queryCommand.Parameters.AddWithValue("@Telephone", person.telephone);
                queryCommand.Parameters.AddWithValue("@id", person.id);
                queryCommand.ExecuteNonQuery();
        }
        public void DeleteFromTable(int id)
        {
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"HomeBUY\".\"" + tableName + "\" WHERE \"id\" = @id", dbc.Connection);
                queryCommand.Parameters.AddWithValue("@id", id);
                queryCommand.ExecuteNonQuery();
        }
    }
}
