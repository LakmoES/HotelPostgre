using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Director;
using Admin;
using Repositories;
using Npgsql;

namespace Enter
{
    public partial class FormLogin : Form
    {
        SecureProcessor secureProcessor;
        public FormLogin()
        {
            InitializeComponent();
            secureProcessor = new SecureProcessor();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (secureProcessor.Login(username, password))
            {

                this.Hide();
                switch (User.role)
                {
                    case 0: new FormAdmin().ShowDialog(); break;
                    case 1: new FormDirector().ShowDialog(); break;
                }
                this.Show();
            }
            else MessageBox.Show("Произошла ошибка. Проверьте правильность ввода имени и пароля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
