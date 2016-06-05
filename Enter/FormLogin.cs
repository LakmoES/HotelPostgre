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
using Staff;
using Npgsql;

namespace Enter
{
    public partial class FormLogin : Form
    {
        private IRepositoryFactory repositoryFactory;
        private ISecureRepositoryFactory secureRepositoryFactory;
        private SecureProcessor secureProcessor;
        public FormLogin(SecureProcessor secureProcessor, IRepositoryFactory repositoryFactory, ISecureRepositoryFactory secureRepositoryFactory/*, IRepositoryFactory repositoryFactory*/)
        {
            InitializeComponent();
            this.secureProcessor = secureProcessor;
            this.repositoryFactory = repositoryFactory;
            this.secureRepositoryFactory = secureRepositoryFactory;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (secureProcessor.Login(username, password))
            {
                //MessageBox.Show(String.Format("{0} {1} {2}", User.name, User.role.ToString(), User.subrole.ToString()));
                this.Hide();
                switch (User.role)
                {
                    case 1: new FormAdmin(repositoryFactory, secureRepositoryFactory).ShowDialog(); break;
                    case 2: new FormDirector(repositoryFactory).ShowDialog(); break;
                    case 3: new FormStaff(repositoryFactory).ShowDialog(); break;
                }
                this.Show();
            }
            else MessageBox.Show("Произошла ошибка. Проверьте правильность ввода имени и пароля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                Login();
            }
        }
    }
}
