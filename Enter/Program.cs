using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;
using Npgsql;

namespace Enter
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //IRepositoryFactory repositoryFactory = new RepositoryFactory();
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=root;Database=postgres;");
            DBConnection.Instance.setConnection(conn);
            DBConnection.Instance.openConnection();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            DBConnection.Instance.closeConnection();
        }
    }
}
