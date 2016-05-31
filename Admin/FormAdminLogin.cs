using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;

namespace Admin
{
    public partial class FormAdminLogin : Form
    {
        string username, password;
        public FormAdminLogin()
        {
            InitializeComponent();
        }

        private void FormAdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            SecureProcessor.Login(User.name, User.password);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.username = this.textBoxUsername.Text.Trim(' ');
            this.password = this.textBoxPassword.Text.Trim(' ');

            if (SecureProcessor.Login(username, password, "roles"))
            {
                this.Hide();
                new FormUsers().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверная пара логин:пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
