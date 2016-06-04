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
            //string enc = SecureCrypt.Encrypt("user", SecureConst.sha1Key);
            //string dec = SecureCrypt.Decrypt(enc, SecureConst.sha1Key);
            //Clipboard.SetText(enc);
            //MessageBox.Show(enc + "\r\n" + dec);
            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin(repositoryFactory));
                DBConnection.Instance.closeConnection();
            }
            catch (PostgresException pEx) { MessageBox.Show("Произошла критическая ошибка базы данных.\r\nПриложение завершит свою работу.\r\n" + pEx.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception) { MessageBox.Show("Произошла критическая ошибка.\r\nПриложение завершит свою работу.", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
