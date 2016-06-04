﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Repositories;
using Npgsql;

namespace Enter
{
    static class Program
    {
        /// <summary
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string key = "8fLZh0Ku";
            //string iv = "UQNtDuJH";
            //string enc = SecureCrypt.DESEncrypt("user", key, iv);
            //string dec = SecureCrypt.DESDecrypt(enc, key, iv);
            //Clipboard.SetText(enc);
            //MessageBox.Show(enc + "\r\n" + dec);

            try
            {
                DBConnection dbc = new DBConnection(null);
                ISecureRepositoryFactory secureRepositoryFactory = new SecureRepositoryFactory(dbc);
                IRepositoryFactory repositoryFactory = new RepositoryFactory(dbc);
                SecureProcessor secureProcessor = new SecureProcessor(dbc,
                    secureRepositoryFactory,
                    ConfigurationManager.AppSettings.Get("user"),
                    ConfigurationManager.AppSettings.Get("password"));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin(secureProcessor, repositoryFactory, secureRepositoryFactory));

                if (dbc.Connection != null)
                    dbc.CloseConnection();
            }
            catch (PostgresException pEx) { MessageBox.Show("Произошла критическая ошибка базы данных.\r\nПриложение завершит свою работу.\r\n" + pEx.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    //catch (Exception ex) { MessageBox.Show("Произошла критическая ошибка.\r\nПриложение завершит свою работу.\r\n\r\n" + ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
}
    }
}
