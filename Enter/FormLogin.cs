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
using EditForms;
using Repositories;
using Npgsql;

namespace Enter
{
    public partial class FormLogin : Form
    {
        //IRepositoryFactory repositoryFactory;
        public FormLogin(/*IRepositoryFactory repositoryFactory*/)
        {
            InitializeComponent();
            //this.repositoryFactory = repositoryFactory;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (radioButtonAdmin.Checked)
                new FormAdmin().ShowDialog();
            else if (radioButtonDirector.Checked)
                new FormDirector().ShowDialog();
            this.Show();
        }
    }
}
