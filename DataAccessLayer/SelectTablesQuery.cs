using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;

namespace DataAccessLayer
{
    public class SelectTablesQuery
    {
        public static List<DBCompany> getCompanyTable()
        {
            List<DBCompany> companyTable = new List<DBCompany>();
            DBCompany companyTbl;

            string commPart = "SELECT * FROM \"HomeBUY\".\"Company\"";
            try
            {
                // открываем соединение
                SQLProcessor.Instance.connect("postgres", "root");

                NpgsqlDataReader readerUserTable = SQLProcessor.Instance.executeWResult(commPart);

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    Application.DoEvents();
                    companyTbl = new DBObjects.DBCompany(
                        Convert.ToInt32(dbDataRecord["id"]),
                        dbDataRecord["TItle"].ToString(),
                        dbDataRecord["Telephone"].ToString(),
                        dbDataRecord["Address"].ToString()
                        );
                    companyTable.Add(companyTbl);
                }
                SQLProcessor.Instance.disconnect();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp), "Ошибка");
            }
            finally
            {
                // соединение закрыто принудительно
                SQLProcessor.Instance.disconnect();
            }
            return companyTable;
        }
        //public static List<DBObjects.DBObject> getObjectsTable()
        //{
        //    List<DBObjects.DBObject> objectsTable = new List<DBObjects.DBObject>();
        //    DBObjects.DBObject objectTbl;

        //    string commPart = "SELECT * FROM \"HomeBUY\".\"Object\"";
        //    try
        //    {
        //        // открываем соединение
        //        SQLProcessor.Instance.connect("postgres", "root");

        //        NpgsqlDataReader readerUserTable = SQLProcessor.Instance.executeWResult(commPart);

        //        foreach (DbDataRecord dbDataRecord in readerUserTable)
        //        {
        //            Application.DoEvents();
        //            objectTbl = new DBObjects.DBObject(
        //                Convert.ToInt32(dbDataRecord["id"]),
        //                dbDataRecord["Address"].ToString(),
        //                Convert.ToDateTime(dbDataRecord["AddDate"])/*DateTime.Now*/,
        //                parseCost(dbDataRecord["Cost"].ToString()),
        //                Convert.ToInt32(dbDataRecord["Owner"]),
        //                Convert.ToInt32(dbDataRecord["Area"]),
        //                dbDataRecord["AppartamentOrHouse"].ToString(),
        //                Convert.ToInt32(dbDataRecord["NumberOfRooms"])
        //                );
        //            objectsTable.Add(objectTbl);
        //        }
        //        SQLProcessor.Instance.disconnect();
        //    }
        //    catch (NpgsqlException exp)
        //    {
        //        MessageBox.Show(Convert.ToString(exp), "Ошибка");
        //    }
        //    finally
        //    {
        //        // соединение закрыто принудительно
        //        SQLProcessor.Instance.disconnect();
        //    }
        //    return objectsTable;
        //}
        //private static DBObjects.Money parseCost(string s)
        //{
        //    string ammount="";
        //    string currency="";
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
        //    return new DBObjects.Money(Convert.ToInt32(ammount), currency);
        //}

    }
}
