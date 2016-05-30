﻿using System;
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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (SecureProcessor.Login(username, password))
            {
                //MessageBox.Show(String.Format("{0} {1} {2}", User.name, User.role.ToString(), User.subrole.ToString()));
                this.Hide();
                switch (User.role)
                {
                    case 1: new FormAdmin().ShowDialog(); break;
                    case 2: new FormDirector().ShowDialog(); break;
                    case 3: new FormStaff().ShowDialog(); break;
                }
                this.Show();
            }
            else MessageBox.Show("Произошла ошибка. Проверьте правильность ввода имени и пароля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
