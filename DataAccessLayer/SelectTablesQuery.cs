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
        public static List<DBObjects.DBCompany> getCompanyTable()
        {
            List<DBObjects.DBCompany> companyTable = new List<DBObjects.DBCompany>();
            DBObjects.DBCompany companyTbl;

            string commPart = "SELECT * FROM \"HomeBUY\".\"Company\"";
            try
            {
                // открываем соединение
                SQLProcessor.Instance.connect("postgres", "root");

                SQLProcessor.Instance.testRead();
                NpgsqlDataReader readerUserTable = SQLProcessor.Instance.executeWResult(commPart);

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    MessageBox.Show("ELEMENT");
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

    }
}
