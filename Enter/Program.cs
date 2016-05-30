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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            try
            {
                DBConnection.Instance.closeConnection();
            }
            catch (Exception) { }
        }
    }
}
