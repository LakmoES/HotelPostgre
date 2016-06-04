using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Repositories
{
    public class SpecialRepository : ISpecialRepository
    {
        private DBConnection dbc;
        public SpecialRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }
        public int GetDemandOfObject(int objectID, DateTime from, DateTime to)
        {
            int pop = -1;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".proc_objectpopularity(@objectID, @from::date, @to::date);", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@objectID", objectID);
            queryCommand.Parameters.AddWithValue("@from", from.ToString());
            queryCommand.Parameters.AddWithValue("@to", to.ToString());
            NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

            if (dealTableReader.HasRows)
                foreach (System.Data.Common.DbDataRecord dbDataRecord in dealTableReader)
                {
                    pop = Convert.ToInt32(dbDataRecord["proc_objectpopularity"]);
                }
            dealTableReader.Close();

            return pop;
        }
        public List<Tuple<Person, int>> GetSatisfiedClients(float lowerArea, float higherArea, float deltaArea, DateTime from, DateTime to)
        {
            List<Tuple<Person, int>> satisfiedList = new List<Tuple<Person, int>>();
            Tuple<Person, int> satisfied;

            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"HomeBUY\".proc_satisfiedСustomersNew(@lowerArea, @higherArea, @deltaArea, @from::date, @to::date);", dbc.Connection);
            queryCommand.Parameters.AddWithValue("@lowerArea", lowerArea);
            queryCommand.Parameters.AddWithValue("@higherArea", higherArea);
            queryCommand.Parameters.AddWithValue("@deltaArea", deltaArea);
            queryCommand.Parameters.AddWithValue("@from", from.ToString());
            queryCommand.Parameters.AddWithValue("@to", to.ToString());
            NpgsqlDataReader dealTableReader = queryCommand.ExecuteReader();

            if (dealTableReader.HasRows)
                foreach (System.Data.Common.DbDataRecord dbDataRecord in dealTableReader)
                {
                    Person person = new Person(
                        Convert.ToInt32(dbDataRecord["clientid"]),
                        dbDataRecord["clientname"].ToString(),
                        dbDataRecord["clientsurname"].ToString(),
                        dbDataRecord["clienttelephone"].ToString()
                        );
                    int satisf = Convert.ToInt32(dbDataRecord["satisf"]);
                    satisfied = new Tuple<Person, int>(person, satisf);
                    satisfiedList.Add(satisfied);
                }
            dealTableReader.Close();

            return satisfiedList;
        }
    }
}
